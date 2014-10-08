using System.Collections.Generic;
using PASaveEditor;

namespace FileModel {
    internal class ReformStudents : Node {
        public readonly Dictionary<int, ReformStudent> Students = new Dictionary<int, ReformStudent>();


        public ReformStudents(string label)
            : base(label, true) {}

        
        public override void ReadKey(string key, string value) {
            if (!key.Equals("Size")) {
                base.ReadKey(key, value);
            }
        }


        public override Node CreateNode(string label) {
            if (label.Equals("i")) {
                return new ReformStudent(label);
            } else {
                return base.CreateNode(label);
            }
        }


        public override void FinishedReadingNode(Node node) {
            var studentNode = node as ReformStudent;
            if (studentNode != null) {
                Students.Add(studentNode.Id, studentNode);
            }
        }


        public override void WriteProperties(Writer writer) {
            writer.WriteProperty("Size", Students.Count);
        }


        public override void WriteNodes(Writer writer) {
            foreach (ReformStudent student in Students.Values) {
                writer.WriteNode(student);
            }
        }
    }
}