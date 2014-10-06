﻿using System.Collections.Generic;

namespace PASaveEditor.Model {
    internal class Contraband : Node {
        public readonly Dictionary<int, ContrabandItem> Prisoners = new Dictionary<int, ContrabandItem>();
        
        public override void ReadKey(string key, string value) {
            if (!"Size".Equals(key)) {
                // do not store size -- it will be counted and written at save-time
                base.ReadKey(key,value);
            }
        }

        public override Node CreateNode(string label) {
            if (Id.IsI(label)) {
                int prisonerId = Id.ParseI(label);
                ContrabandItem item = new ContrabandItem(prisonerId);
                Prisoners.Add(prisonerId, item);
                return item;

            } else {
                return base.CreateNode(label);
            }
        }
    }
}