using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel
{
    using System;
    using System.Collections.Generic;

    public class ResultRec
    {
        public string RESULT { get; set; }
        public string RESULTMESSAGE { get; set; }
  

        public void setResult(String sResult)
        {
            this.RESULT = sResult;
        }
        public void setRESULTMESSAGE(String sResultMessage)
        {
            this.RESULTMESSAGE = sResultMessage;
        }
    }
}