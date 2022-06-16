using System.Collections.Generic;

using MMC.Helper;

using Xunit;

namespace MMC.Test
{
    public class UnitTestTextParsing
    {
        #region TestMergeJsonKeyValue

        public static IEnumerable<object[]> TestMergeJsonData
        {
            get
            {
                var driverData = new List<object[]>
                {
                    new object[] {
                    new string[] {
                        "{\"��ɫ\":\"����ɫ\",\"���\":\"300ml\",\"��ζ\":\"����\"}",
                        "{\"��ɫ\":\"͸��\",\"���\":\"350ml\",\"��ζ\":\"����\"}",
                        "{\"��ɫ\":\"���ۺ�\",\"���\":\"400ml\",\"��ζ\":\"ˮ����\"}"
                    }
                 }
                };
                return driverData;
            }
        }

        [Theory]
        [MemberData("TestMergeJsonData")]
        public void TestMergeJsonKeyValue(string[] jsonData)
        {
            var mergeStr = TextParsing.MergeJsonKeyValue(jsonData);
            var result = "{\"��ɫ\":[\"����ɫ\",\"͸��\",\"���ۺ�\"],\"���\":[\"300ml\",\"350ml\",\"400ml\"],\"��ζ\":[\"����\",\"����\",\"ˮ����\"]}";
            Assert.Equal(result, mergeStr);
        }

        #endregion
    }
}