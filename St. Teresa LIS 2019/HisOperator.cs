using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace St.Teresa_LIS_2019
{
    public class HisOperator
    {
        private String hisEndPoint;
        private String hisLoginName;
        private String hisPassword;

        public HisOperator()
        {
            hisEndPoint = Properties.Settings.Default.HisEndPoint;
            hisLoginName = Properties.Settings.Default.HisLoginName;
            hisPassword = Properties.Settings.Default.HisPassword;
        }

        public String sentReportToHis(String caseNo, String reportNo, String reportContent, String sentBy)
        {
            String responseXml = null;
            if (reportContent != null)
            {
                try
                {
                    HistologyWebserviceDev.HistologyWebserviceSoapClient client = new HistologyWebserviceDev.HistologyWebserviceSoapClient();
                    responseXml = client.updateResult(hisLoginName, hisPassword, reportContent);

                    

                } catch (Exception ex)
                {
                    responseXml = ex.ToString();
                }
            }

            return responseXml;
        }

    }
}
