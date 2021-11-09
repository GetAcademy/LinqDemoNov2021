using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemoNov2021
{
    class HtmlBuilder
    {
        private string _html = "";

        public void AddTag(string name, string content)
        {
            _html += $"<{name}>{content}</{name}>";
        }

        public HtmlBuilder H1(string content)
        {
            AddTag("H1", content);
            return this;
        }


        public HtmlBuilder H2(string content)
        {
            AddTag("H2", content);
            return this;
        }

        public HtmlBuilder P(string content)
        {
            AddTag("P", content);
            return this;
        }

        public string GetHtml()
        {
            return _html;
        }
    }
}
