using System;
using System.Collections.Generic;
using System.Text;

namespace GhostService.GhostServicePlugin
{
    public class UpdateCheck
    {
        public string CheckDescription
        { get; set; }
        public string Check
        { get; set; }
        public string PassResult
        { get; set; }
        public CheckType TheCheckType
        { get; set; }

        public UpdateCheck()
        {
        }

        public UpdateCheck(string checkDescription, string check, string passResult, CheckType theCheckType):
            this()
        {
            this.Check = check;
            this.PassResult = passResult;
            this.TheCheckType = theCheckType;
            this.CheckDescription = checkDescription;
        }

        public bool CheckPassed(string checkResult)
        {
            switch (TheCheckType)
            { 
                case CheckType.Equal:
                    return (string.Compare(checkResult, PassResult) == 0);
                    break;
                case CheckType.Larger:
                    return (string.Compare(checkResult,PassResult) > 0);
                    break;
                case CheckType.Less:
                    return (string.Compare(checkResult, PassResult) < 0);
                    break;
                default:
                    return false;
            }
             
        }
       
    }
}
