using System;

namespace RSNP.Testing {
    class Program {
        static void Main(string[] args) {
            new Program().Start().Wait().Dispose();
        }

        public Program Start() {
            return this;
        }

        public Program Wait() {
            return this;
        }

        public void Dispose() {

        }
    }
}
