﻿using CALforDataTransfer.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Models
{
    public class BCommonRepository
    {
        public ICommonRepository icommon;
        public BCommonRepository(ICommonRepository iCommon)
        {
            this.icommon = iCommon;
        }
        public List<CommonTution> GetAllTution()
        {
            List<CommonTution> lstTution = null;
            try
            {
                lstTution = icommon.GetAllTution();
            }
            catch
            {
                lstTution = null;
            }
            return lstTution;
        }
        public List<CommonStudent> GetAllStudent()
        {
            List<CommonStudent> lstStudent = null;
            try
            {
                lstStudent = icommon.GetAllStudent();
            }
            catch
            {
                lstStudent = null;
            }
            return lstStudent;
        }
        public List<CommonTeacher> GetAllTacher()
        {
            List<CommonTeacher> lstTeacher = null;
            try
            {
                lstTeacher = icommon.GetAllTeacher();
            }
            catch
            {
                lstTeacher = null;
            }
            return lstTeacher;
        }
        public CommonTeacher GetTeacher(int id)
        {
            CommonTeacher teacher = null;
            try
            {
                teacher = icommon.GetTeacher(id);
            }
            catch
            {
                teacher = null;
            }
            return teacher;
        }
        public CommonStudent GetStudent(int id)
        {
            CommonStudent student = null;
            try
            {
                student = icommon.GetStudent(id);
            }
            catch
            {
                student = null;
            }
            return student;
        }
        public CommonTution GetTution(int id)
        {
            CommonTution tution = null;
            try
            {
                tution = icommon.GetTution(id);
            }
            catch
            {
                tution = null;
            }
            return tution;
        }
    }
}
