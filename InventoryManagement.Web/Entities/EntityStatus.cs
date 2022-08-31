﻿namespace InventoryManagement.Web.Entities
{
    public class EntityStatus
    {
        public static int Deleted { get { return -404; } }
        public static int Inactive { get { return -1; } }
        public static int Active { get { return 1; } }
    }
}
