﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS.Domain.Abstract;
using CMS.Domain.Entities;
using CMS.Domain.DataAccess;


namespace CMS.Domain.Models
{
    public class PageRepository : IPageRepository
    {
        public void Create(Page m_Page)
        {
            DBPage.Create(m_Page);
        }

        public Page RetrieveOne(int m_Id)
        {
            Page m_Page = DBPage.RetrieveOne(m_Id);
            m_Page.TemplateName = DBPage.GetTemplateName(m_Page.TemplateId);

            return m_Page;
        }

        public List<Page> RetrieveAll(int m_Id)
        {
            List<Page> m_Pages = DBPage.RetrieveAll(m_Id);
            return m_Pages;
        }

        public void Update(Page m_Page)
        {
            DBPage.Update(m_Page);
        }

        public bool TrashCan(int m_Id)
        {
            if (DBPage.TrashCan(m_Id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Delete(int m_Id)
        {

        }

        public int Publish(int id)
        {
            int ParentId = DBPage.Publish(id);

            return ParentId;
        }

        public void LockPage(int pid)
        {
            DBPage.lockPage(pid);
        }

        public void UnlockPage(int pid)
        {
            DBPage.unlockPage(pid);
        }
    }
}