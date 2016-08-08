using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Patterns;

namespace OOPS
{
    class Program
    {
        static int[] elements = new int[4] { 1, 2, 4, 6 };
        static void Main(string[] args)
        {
            var topic1=new Topic{Description="this is topic 1",Name="Topic1"};
            var topic2=new Topic{Description="this is topic 2",Name="Topic2"};
            Dictionary<Topic, List<ISubscriber>> topics = new Dictionary<Topic, List<ISubscriber>>();
            topics.Add(topic1, null);
            topics.Add(topic2, null);

            IPublisher publisher = new Publisher(topics);

            ISubscriber subscriberA = new Subscriber("A");
            ISubscriber subscriberC = new Subscriber("C");

            publisher.Subscribe(topic1,subscriberA);
            publisher.Subscribe(topic1, new Subscriber("B"));
            publisher.Subscribe(topic2, subscriberC);
            publisher.Subscribe(topic2, new Subscriber("D"));
            publisher.Publish(topic1);
            publisher.Publish(topic2);

            publisher.UnSubscribe(topic1,subscriberA);
            publisher.UnSubscribe(topic2, subscriberC);

            publisher.Publish(topic1);
            publisher.Publish(topic2);

            Console.ReadKey();
        }
        static int Sum(int i, int summedValue)
        {
            if (i < elements.Length)
            {
                int tempSum = summedValue;
                if (elements[i] % 2 == 0)
                    tempSum = elements[i] + summedValue;
                i++;
                Sum(i, tempSum);
            }
            return summedValue;
        }
    }

    public class Door
    {
        static Door _instance = null;
        private Door()
        {

        }

        static Door()
        {
            _instance = new Door();
        }

        public static Door Instance()
        {
            return _instance;
        }
    }

    public class GenericClassTester
    {
        public void TestMethod()
        {
            Person[] p = { new Person(), new Person() };

            Animal[] a = { new Animal(), new Animal() };

            GenericEnumerable<Person> persons = new GenericEnumerable<Person>(p);

            GenericEnumerable<Animal> animals = new GenericEnumerable<Animal>(a);
        }
    }

    // Generic IEnumerable Class
    public class GenericEnumerable<T> : IEnumerable<T>
    {
        List<T> _elements;

        public GenericEnumerable(T[] elements)
        {
            this._elements = new List<T>(elements);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return this._elements.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this._elements.GetEnumerator();
        }
    }
}