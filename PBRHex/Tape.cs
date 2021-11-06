using System;
using System.Collections.Generic;

namespace PBRHex
{
    public class Tape<T>
    {
        public int Count => tape.Count;
        public int Position { get; private set; }

        private List<T> tape;

        public Tape() {
            tape = new List<T>();
            Position = -1;
        }

        public T GetCurrent() {
            return tape[Position];
        }

        public T MoveForward() {
            if(Position < tape.Count - 1)
                Position++;
            return tape[Position];
        }

        public T MoveBackward() {
            if(Position > 0)
                Position--;
            return tape[Position];
        }

        public bool HasFuture() {
            return Position < tape.Count - 1;
        }

        public bool HasPast() {
            return Position > 0;
        }

        public void Insert(T item) {
            // discard future
            tape = tape.GetRange(0, Position + 1);
            tape.Add(item);
            MoveForward();
        }
    }
}
