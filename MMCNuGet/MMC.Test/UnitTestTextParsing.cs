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
                        "{\"颜色\":\"淡黄色\",\"规格\":\"300ml\",\"口味\":\"蜂蜜\"}",
                        "{\"颜色\":\"透明\",\"规格\":\"350ml\",\"口味\":\"柠檬\"}",
                        "{\"颜色\":\"淡粉红\",\"规格\":\"400ml\",\"口味\":\"水蜜桃\"}"
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
            var result = "{\"颜色\":[\"淡黄色\",\"透明\",\"淡粉红\"],\"规格\":[\"300ml\",\"350ml\",\"400ml\"],\"口味\":[\"蜂蜜\",\"柠檬\",\"水蜜桃\"]}";
            Assert.Equal(result, mergeStr);
        }

        #endregion
    }
}