﻿
namespace Application.Models
{
    public class EmailModel
    {
        public string From { get; set; }
        public string FromName { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; }
    }
}
