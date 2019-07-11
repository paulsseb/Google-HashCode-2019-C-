using System;
using System.Collections.Generic;
using System.Text;

namespace HashcodeTeamMak
{
    class Image
    {
        public string hov { get; set; }
        public decimal tagsno { get; set; }
        public int position { get; set; }
        public int count { get; set; }

        public List<string> listoftags;

        public Image()
        {
            listoftags = new List<string>();

        }
    }
}
