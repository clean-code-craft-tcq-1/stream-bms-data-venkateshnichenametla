using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BatteryStreamReceiver.Test
{
    public static class AssertObjectsHelper
    {
        public static bool ExpectedAndActualObjectsAreEqual(List<BatteryParameters> expectedList, List<BatteryParameters> actualList)
        {
            bool result = false;
            if (expectedList.Count == actualList.Count)
            {
                for (int i = 0; i < expectedList.Count(); i++)
                {
                    var expectedValue = expectedList[i];
                    var actualValue = actualList[i];
                    result = AssertPropertiesOfObjectAreEquals((BatteryParameters)actualValue, (BatteryParameters)expectedValue);
                }
            }
            else
            {
                result = false;
            }
            return result;
        }
        private static bool AssertPropertiesOfObjectAreEquals(BatteryParameters actualObject, BatteryParameters expectedObject)
        {
            bool result = false;
            PropertyInfo[] properties = expectedObject.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object expectedValue = property.GetValue(expectedObject, null);
                object actualValue = property.GetValue(actualObject, null);
                if (!Equals(expectedValue, actualValue))
                {
                    result = false;
                    break;
                }
            }
            result = true;
            return result;

        }
    }
}
