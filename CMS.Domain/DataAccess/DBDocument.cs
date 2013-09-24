﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS.Domain.Entities;
using CMS.Domain.HelperClasses;
using System.Data.SqlClient;

namespace CMS.Domain.DataAccess
{
    public class DBDocument
    {
        public static void Create(Document m_Document)
        {
            SqlConnection conn = DB.DbConnect();
            conn.Open();

            string queryString = "INSERT INTO CMS_Documents(name, parentId, fileType, contentGroup) VALUES(@name, @parentId, @fileType, @contentGroup)";
            SqlCommand insertDoc = new SqlCommand(queryString, conn);
            insertDoc.Parameters.AddWithValue("name", m_Document.Name);
            insertDoc.Parameters.AddWithValue("parentId", m_Document.ParentId);
            insertDoc.Parameters.AddWithValue("fileType", m_Document.FileType);
            insertDoc.Parameters.AddWithValue("contentGroup", m_Document.ContentGroup);

            insertDoc.ExecuteNonQuery();

            conn.Close();
        }

        public static Document RetrieveOne(int id)
        {
            SqlConnection conn = DB.DbConnect();
            conn.Open();

            string queryString = "SELECT * FROM CMS_Documents where id = @id";
            SqlCommand getDocument = new SqlCommand(queryString, conn);
            getDocument.Parameters.AddWithValue("id", id);
            SqlDataReader documentReader = getDocument.ExecuteReader();

            Document m_Document = new Document();

            if (documentReader.Read())
            {
                m_Document.Id = documentReader.GetInt32(0);
                m_Document.Name = documentReader.GetString(1);
                m_Document.ParentId = documentReader.GetInt32(2);
                m_Document.FileType = documentReader.GetString(3);
                m_Document.ContentGroup = documentReader.GetInt32(4);
            }

            conn.Close();

            return m_Document;
        }

        public static List<Document> RetriveAll(int id)
        {
            SqlConnection conn = DB.DbConnect();
            conn.Open();

            string queryString = "SELECT * FROM CMS_Documents where parentId = @parentId";
            SqlCommand getDocuments = new SqlCommand(queryString, conn);
            getDocuments.Parameters.AddWithValue("parentId", id);
            SqlDataReader documentsReader = getDocuments.ExecuteReader();

            List<Document> m_Documents = new List<Document>();

            while (documentsReader.Read())
            {
                Document tempDoc = new Document();

                tempDoc.Id = documentsReader.GetInt32(0);
                tempDoc.Name = documentsReader.GetString(1);
                tempDoc.ParentId = documentsReader.GetInt32(2);
                tempDoc.FileType = documentsReader.GetString(3);
                tempDoc.ContentGroup = documentsReader.GetInt32(4);

                m_Documents.Add(tempDoc);
            }

            conn.Close();

            return m_Documents;
        }

        public static void Update(Document m_Document)
        {
            SqlConnection conn = DB.DbConnect();
            conn.Open();

            string queryString = "UPDATE CMS_Documents SET name = @name, parentId = @parentId, fileType = @fileType, contentGroup = @contentGroup WHERE id = @id";
            SqlCommand updateDocument = new SqlCommand(queryString, conn);
            updateDocument.Parameters.AddWithValue("name", m_Document.Name);
            updateDocument.Parameters.AddWithValue("parentId", m_Document.ParentId);
            updateDocument.Parameters.AddWithValue("fileType", m_Document.FileType);
            updateDocument.Parameters.AddWithValue("contentGroup", m_Document.ContentGroup);
            updateDocument.Parameters.AddWithValue("id", m_Document.Id);

            updateDocument.ExecuteNonQuery();

            conn.Close();
        }

        public static void Delete(int id)
        {
            SqlConnection conn = DB.DbConnect();
            conn.Open();

            string queryString = "DELETE FROM CMS_Documents where id = @id";
            SqlCommand deleteDocument = new SqlCommand(queryString, conn);
            deleteDocument.Parameters.AddWithValue("id", id);
            deleteDocument.ExecuteNonQuery();

            conn.Close();
        }


    }
}