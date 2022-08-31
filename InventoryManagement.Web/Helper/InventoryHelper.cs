using System.ComponentModel;

namespace InventoryManagement.Web.Helper
{
    public static class InventoryHelper
    {
        public static Dictionary<int, string> LoadEmumToDictionary<T>(List<int> excludeList = null, bool? includeAll = null)
        {
            var enumType = typeof(T);
            return LoadEmumToDictionary(enumType, excludeList, includeAll);
        }

        public static Dictionary<int, string> LoadEmumToDictionary(Type enumType, List<int> excludeList = null, bool? includeAll = null)
        {
            Dictionary<int, string> enumToDictionary = new Dictionary<int, string>();
            if (includeAll != null && includeAll == true)
            {
                enumToDictionary.Add(0, "All");
            }
            var enumAllItems = Enum.GetValues(enumType);
            foreach (var currentItem in enumAllItems)
            {
                if ((excludeList != null && !excludeList.Contains((int)currentItem)) || (excludeList == null))
                {
                    DescriptionAttribute[] allDescAttributes = (DescriptionAttribute[])enumType.GetField(currentItem.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
                    string description = allDescAttributes.Length > 0
                        ? allDescAttributes[0].Description
                        : currentItem.ToString();

                    enumToDictionary.Add((int)currentItem, description);
                }
            }
            return enumToDictionary;
        }

        public static string GetEmumIdToValue<T>(int enumId)
        {
            try
            {
                string value = "-";
                Dictionary<int, string> enumToDictionary = LoadEmumToDictionary<T>();
                if (enumToDictionary.Any())
                {
                    value = enumToDictionary.Where(x => x.Key == enumId).Select(x => x.Value).Take(1).SingleOrDefault();
                }
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
