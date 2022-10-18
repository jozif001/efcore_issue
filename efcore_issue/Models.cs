using System.Collections.Generic;

namespace efcore_issue
{
    public class Root
    {
        public int Id { get; set; }
        public string AnyProp { get; set; }
        public Child1 Child1 { get; set; }
        public Child2 Child2 { get; set; }
        public List<Child3> Child3 { get; set; }
    }

    public class Child1
    {
        public int Id { get; set; }
        public string AnyProp { get; set; }
        public int RootId { get; set; }
    }

    public class Child2
    {
        public int Id { get; set; }
        public string AnyProp { get; set; }
        public int RootId { get; set; }
    }

    public class Child3
    {
        public int Id { get; set; }
        public string AnyProp { get; set; }
        public int RootId { get; set; }
    }
}
