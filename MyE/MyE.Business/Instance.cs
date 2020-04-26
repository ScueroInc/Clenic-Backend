using MyE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyE.Business.Component
{
    public class Instance
    {
        private static SqlContext context;
        public static SqlContext Repository {
            get {
                if (context==null) {
                    context = new SqlContext();
                }
                return context;
            }
            set {
                Instance.Repository = value;
            }
        }
    }
}
