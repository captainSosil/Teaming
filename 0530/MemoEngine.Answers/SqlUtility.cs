using System;
using System.Collections.Generic;
using System.Text;

namespace MemoEngine.Answers
{
    /// <summary>
    /// SQL 문자열 처리 (C#용 문자열을 SQL문자열로 사용 하는것으로 바꾸기) : SQL문이 실행되지 않고 문자열 자체로 검색할 때 사용
    /// </summary>
    class SqlUtility
    {
        #region EncodeSqlString() 함수
        /// <summary>
        /// 주어진 문자열에 있는 SQL 특수 문자를 바꿈. (바꿀 문자열)
        /// </summary>
        /// <param name="strContent">SQL Server에 전달된 문자열</param>
        /// <returns>SQL 특수 문자가 변경된 문자열</returns>
        public static string EncodeSqlString(string strContent)
        {
            if (strContent != null)
            {
                string strTemp = strContent;
                strTemp = strTemp.Replace("%", "[%]");
                strTemp = strTemp.Replace("_", "[_]");
                strTemp = strTemp.Replace("@", "[@]");
                strTemp = strTemp.Replace("'", "''");
                return strTemp;
            }
            return "";
        }
        #endregion
    }
}

