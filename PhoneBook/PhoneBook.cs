using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public enum PhoneBook
    {
        INSTANCE
    }

    static class PhoneBookHelper
    {
        private static Dictionary<string, List<PhoneBookSubscriber>> subscribers = new Dictionary<string, List<PhoneBookSubscriber>>();
        private static Dictionary<string, object> entries = new Dictionary<string, object>();

        public static void Register(this PhoneBook phoneBook, string keyword, PhoneBookSubscriber subscriber)
        {
            List<PhoneBookSubscriber> subscriberList = PhoneBookHelper.subscribers[keyword];
            if (subscriberList == null)
            {
                subscriberList = new List<PhoneBookSubscriber>();
                PhoneBookHelper.subscribers.Add(keyword, subscriberList);
            }
            subscriberList.Add(subscriber);
        }

        public static void Unregister(this PhoneBook phoneBook, string keyword, PhoneBookSubscriber subscriber)
        {
            List<PhoneBookSubscriber> subscriberList = PhoneBookHelper.subscribers[keyword];
            if (subscriberList != null)
            {
                subscriberList.Remove(subscriber);
            }
        }

        public static void Notice(this PhoneBook phoneBook, string keyword)
        {
            List<PhoneBookSubscriber> subscriberList = PhoneBookHelper.subscribers[keyword];
            if (subscriberList != null)
            {
                foreach (PhoneBookSubscriber subscriber in subscriberList)
                {
                    subscriber.Notify(keyword);
                }
            }
        }

        public static void AddEntry(this PhoneBook phoneBook, string name, object callable)
        {
            try
            {
                object previousEntry = PhoneBookHelper.entries[name];
                throw new DuplicateIndexException();
            }
            catch (KeyNotFoundException)
            {
                PhoneBookHelper.entries.Add(name, callable);
            }
        }

        public static void RemoveEntry(this PhoneBook phoneBook, string name)
        {
            PhoneBookHelper.entries.Remove(name);
        }

        public static object Call(this PhoneBook phoneBook, string name)
        {
            return PhoneBookHelper.entries[name];
        }
    }
}
