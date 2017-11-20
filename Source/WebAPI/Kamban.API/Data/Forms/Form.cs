using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kamban.API.Data.Forms
{
    public class Form
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public FormFields[] fields { get; set; }
        public string UserId { get; set; }
    }

    public class FormFields
    {
        public int Index { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public string Instruction { get; set; }
        public bool Mandatory { get; set; }
    }
}