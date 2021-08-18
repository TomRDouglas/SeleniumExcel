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

    public  class TestRec
    {
        public string RESULT { get; set; }
        public string SERIES { get; set; }
        public string STEP { get; set; }
        public string SUBSTEP { get; set; }
        public string CMD { get; set; }
        public string SUBCMD { get; set; }
        public Int32? IPARM1 { get; set; }
        public Int32? IPARM2 { get; set; }
        public string SPARM1 { get; set; }
        public string SPARM2 { get; set; }
        public string RES1 { get; set; }
        public string RES2 { get; set; }
        public string RES3 { get; set; }
        public Int32? ITEST { get; set; }
        public Int32? TESTLOGLEVEL { get; set; }
        public string MODE { get; set; }
        public string ITEM_TYPE { get; set; }
        public string ITEM_URLTYPE { get; set; }
        public string ITEMURL { get; set; }


        public void setRec(DataGridViewRow dgr, List<DataGridViewColumn> columnList) {
            var tempVAR = (dynamic)null;
            string replaceWith = "";
            

            this.RESULT = Convert.ToString(dgr.Cells[columnList.FindIndex(c => c.HeaderText == "RESULT")].Value);
            this.SERIES = Convert.ToString(dgr.Cells[columnList.FindIndex(c => c.HeaderText == "SERIES")].Value);
            this.STEP = Convert.ToString(dgr.Cells[columnList.FindIndex(c => c.HeaderText == "STEP")].Value);
            this.SUBSTEP = Convert.ToString(dgr.Cells[columnList.FindIndex(c => c.HeaderText == "SUBSTEP")].Value);
            this.CMD = Convert.ToString(dgr.Cells[columnList.FindIndex(c => c.HeaderText == "CMD")].Value);
            this.SUBCMD = Convert.ToString(dgr.Cells[columnList.FindIndex(c => c.HeaderText == "SUBCMD")].Value);

            tempVAR = dgr.Cells[columnList.FindIndex(c => c.HeaderText == "IPARM1")].Value;
            if (!(tempVAR is DBNull)) this.IPARM1 = Convert.ToInt32(tempVAR); else this.IPARM1 = null;

            tempVAR = dgr.Cells[columnList.FindIndex(c => c.HeaderText == "IPARM2")].Value;
            if (!(tempVAR is DBNull)) this.IPARM2 = Convert.ToInt32(tempVAR); else this.IPARM2 = null;


            this.SPARM1 = Convert.ToString(dgr.Cells[columnList.FindIndex(c => c.HeaderText == "SPARM1")].Value);
            this.SPARM2 = Convert.ToString(dgr.Cells[columnList.FindIndex(c => c.HeaderText == "SPARM2")].Value);


            this.RES1 = Convert.ToString(dgr.Cells[columnList.FindIndex(c => c.HeaderText == "RES1")].Value);
            this.RES2 = Convert.ToString(dgr.Cells[columnList.FindIndex(c => c.HeaderText == "RES2")].Value);
            this.RES3 = Convert.ToString(dgr.Cells[columnList.FindIndex(c => c.HeaderText == "RES3")].Value);
  
           
            tempVAR = dgr.Cells[columnList.FindIndex(c => c.HeaderText == "ITEST")].Value;
            if (!(tempVAR is DBNull)) this.ITEST = Convert.ToInt32(tempVAR); else this.ITEST = null;

            tempVAR = dgr.Cells[columnList.FindIndex(c => c.HeaderText == "TESTLOGLEVEL")].Value;
            if (!(tempVAR is DBNull)) this.TESTLOGLEVEL = Convert.ToInt32(tempVAR); else this.TESTLOGLEVEL = 4;


            this.MODE = Convert.ToString(dgr.Cells[columnList.FindIndex(c => c.HeaderText == "MODE")].Value);
            this.ITEM_TYPE = Convert.ToString(dgr.Cells[columnList.FindIndex(c => c.HeaderText == "ITEM_TYPE")].Value);
            this.ITEM_URLTYPE = Convert.ToString(dgr.Cells[columnList.FindIndex(c => c.HeaderText == "ITEM_URLTYPE")].Value);


            this.ITEMURL = Convert.ToString(dgr.Cells[columnList.FindIndex(c => c.HeaderText == "ITEMURL")].Value);

            //======================= Clean up strings
            this.RESULT = this.RESULT.Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith);
            this.SERIES = this.SERIES.Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith);
            this.STEP = this.STEP.Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith);
            this.SUBSTEP = this.SUBSTEP.Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith);
            this.CMD = this.CMD.Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith);
            this.SUBCMD = this.SUBCMD.Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith);
            this.SPARM1 = this.SPARM1.Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith);
            this.SPARM2 = this.SPARM2.Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith);
            this.RES1 = this.RES1.Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith);
            this.RES2 = this.RES2.Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith);
            this.RES3 = this.RES3.Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith);
            this.MODE = this.MODE.Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith);
            this.ITEM_TYPE = this.ITEM_TYPE.Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith);
            this.ITEM_URLTYPE = this.ITEM_URLTYPE.Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith);
            this.ITEMURL = this.ITEMURL.Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith);
            
        }
    }
}
