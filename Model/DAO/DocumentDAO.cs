﻿using System.Collections.Generic;
using System.Linq;
using Model.EF;
using up_down.Models;

namespace Model.DAO
{
    public class DocumentDAO
    {
        public WCDbContext WcDbContext;

        public DocumentDAO()
        {
            WcDbContext = new WCDbContext();
        }

        public List<document> list()
        {
            var list = WcDbContext.documents.ToList();
            return list;
        }
    }
}