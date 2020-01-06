using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace St.Teresa_LIS_2019
{
    public class EhrBarCode
    {
        public const string DATE_FORMAT_YEAR = "yyyy";
        public const string DATE_FORMAT_YEAR_MONTH = DATE_FORMAT_YEAR + "-MM";
        public const string DATE_FORMAT_FULL = DATE_FORMAT_YEAR_MONTH + "-dd";
        public const string DATE_FORMAT_REQUEST_DATE = DATE_FORMAT_FULL;

        public string referralNo { get; set; }
        public string hcpId { get; set; }
        public string hciId { get; set; }
        public string hciName { get; set; }
        public string ehrNo { get; set; }
        public string surname { get; set; }
        public string givenName { get; set; }
        public string chiName { get; set; }
        public string sex { get; set; }
        public string dob { get; set; }
        public string hkid { get; set; }
        public string refDoctorName { get; set; }
        public string organization { get; set; }
        public string requestDate { get; set; }

        public EhrBarCode ()
        {

        }

        public override string ToString()
        {
            String o = "referralNo : " + referralNo + Environment.NewLine;
            o = o + "hcpId : " + hcpId + Environment.NewLine;
            o = o + "hciId : " + hciId + Environment.NewLine;
            o = o + "hciName : " + this.getHciNamePlain() + Environment.NewLine;
            o = o + "ehrNo : " + ehrNo + Environment.NewLine;
            o = o + "surname : " + surname + Environment.NewLine;
            o = o + "givenName : " + givenName + Environment.NewLine;
            o = o + "chiName : " + this.getChiNamePlain() + Environment.NewLine;
            o = o + "sex : " + sex + Environment.NewLine;
            o = o + "dob : " + this.getDobInDate() + Environment.NewLine;
            o = o + "hkid : " + this.getHkidWithBracket() + Environment.NewLine;
            o = o + "refDoctorName : " + this.getDoctorNamePlain() + Environment.NewLine;
            o = o + "organization : " + organization + Environment.NewLine;
            o = o + "requestDate : " + this.getRequestDatePlain() + Environment.NewLine;
            return o;
        }

        public static EhrBarCode getInstance(string barcode)
        {
            EhrBarCode c = new EhrBarCode();

            if (barcode == null || barcode == "")
            {
                return null;
            }
            else
            {
                string[] ary = barcode.Split('|');
                if (ary == null || ary.Length < 1)
                {
                    return null;
                }

                if (ary.Length == 14)
                {
                    int i = 0;
                    c.referralNo = processInputString(ary[i]);

                    i++;
                    c.hcpId = processInputString(ary[i]);

                    i++;
                    c.hciId = processInputString(ary[i]);

                    i++;
                    c.hciName = processInputString(ary[i], false);

                    i++;
                    c.ehrNo = processInputString(ary[i]);

                    i++;
                    c.surname = processInputString(ary[i]);

                    i++;
                    c.givenName = processInputString(ary[i]);

                    i++;
                    c.chiName = processInputString(ary[i], false);

                    i++;
                    c.sex = processInputString(ary[i]);

                    i++;
                    c.dob = processInputString(ary[i]);

                    i++;
                    c.hkid = processInputString(ary[i]);

                    i++;
                    c.refDoctorName = processInputString(ary[i], false);

                    i++;
                    c.organization = processInputString(ary[i]);

                    i++;
                    c.requestDate = processInputString(ary[i]);

                }
                else
                {
                    return null;
                }
            }

            return c;
        }

        public static string processInputString(string i)
        {
            return processInputString(i, true);
        }

        public static string processInputString(string i, Boolean toUpper)
        {
            if (isNotEmpty(i))
            {
                if (toUpper)
                {
                    return i.Trim().ToUpper();
                } 
                else
                {
                    return i.Trim();
                }
                
            }
            else
            {
                return null;
            }
        }

        public static Boolean isNotEmpty(string i)
        {
            if (i == null || i == "")
            {
                return false;
                
            }
            else
            {
                if (i.Trim() == "")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public string getHkidWithBracket()
        {
            if (hkid != null)
            {
                return hkid.Substring(0, hkid.Length - 1) + "(" + hkid.Substring(hkid.Length - 1, 1) + ")";
            }
            else
            {
                return null;
            }
        }

        public DateTime? getDobInDate()
        {
            if (dob == null)
            {
                return null;
            }
            else
            {
                if (dob.Length == 4)
                {
                    return DateTime.ParseExact(dob + "-01-01", DATE_FORMAT_FULL, System.Globalization.CultureInfo.InvariantCulture);
                }
                else if (dob.Length == 7)
                {
                    return DateTime.ParseExact(dob + "-01", DATE_FORMAT_FULL, System.Globalization.CultureInfo.InvariantCulture);
                }
                else if (dob.Length == 10)
                {
                    return DateTime.ParseExact(dob, DATE_FORMAT_FULL, System.Globalization.CultureInfo.InvariantCulture);
                }
                else
                {
                    return null;
                }
            }
        }

        public string decodeBase64(String i)
        {
            if (i == null || i == "")
            {
                return null;
            }

            byte[] data = System.Convert.FromBase64String(i);
            String o = Encoding.UTF8.GetString(data);

            return o;
        }

        public DateTime? getRequestDatePlain()
        {
            if (requestDate == null || requestDate == "")
            {
                return null;
            }

            return DateTime.ParseExact(requestDate, DATE_FORMAT_REQUEST_DATE, System.Globalization.CultureInfo.InvariantCulture);
        }

        public String getHciNamePlain()
        {
            return decodeBase64(hciName);
        }

        public String getChiNamePlain()
        {
            return this.decodeBase64(chiName);
        }

        public string getDoctorNamePlain()
        {
            return this.decodeBase64(refDoctorName);
        }

    }
}
