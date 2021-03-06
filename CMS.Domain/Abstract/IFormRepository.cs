﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Domain.Entities;

namespace CMS.Domain.Abstract
{
    public interface IFormRepository
    {
        int Create(Form m_Form);
        Form RetrieveOne(int id);
        List<Form> RetrieveAll();
        void Update(Form m_Form);
        void Delete(int id);
        List<FormField> getFormFields(int id);
        void SortUp(int parentId, int id);
        void SortDown(int parentId, int id);
        void ToggleRequired(int parentId, int id, int value);
        void InsertFormData(string formData, int formId);
    }
}
