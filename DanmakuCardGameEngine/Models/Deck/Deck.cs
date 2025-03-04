using System;
using System.Collections;
using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    public class Deck<TCard> : IDeck<TCard> where TCard : ICard {
        private readonly List<TCard> _cards = new List<TCard>();
        public int Count => _cards.Count;
        public bool IsReadOnly => false;
        public bool IsFixedSize => false;
        public bool IsSynchronized => false;
        public object SyncRoot => this;

        public IEnumerator<TCard> GetEnumerator() => _cards.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _cards.GetEnumerator();

        public void CopyTo(Array array, int index) {
            if (array == null) {
                throw new ArgumentNullException(nameof(array));
            }

            try {
                _cards.CopyTo((TCard[])array, index);
            }
            catch (InvalidCastException ex) {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        public int Add(object value) {
            if (value == null) {
                throw new ArgumentNullException(nameof(value));
            }

            try {
                _cards.Add((TCard)value);
                return 1;
            }
            catch (InvalidCastException ex) {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        public bool Contains(object value) {
            if (value == null) {
                return false;
            }

            try {
                return _cards.Contains((TCard)value);
            }
            catch (InvalidCastException) {
                return false;
            }
        }

        public void Clear() {
            _cards.Clear();
        }

        public int IndexOf(object value) {
            if (value == null) {
                throw new ArgumentNullException(nameof(value));
            }

            try {
                return _cards.IndexOf((TCard)value);
            }
            catch (InvalidCastException ex) {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        public void Insert(int index, object value) {
            if (value == null) {
                throw new ArgumentNullException(nameof(value));
            }

            try {
                _cards.Insert(index, (TCard)value);
            }
            catch (InvalidCastException ex) {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        public void Remove(object value) {
            if (value == null) {
                throw new ArgumentNullException(nameof(value));
            }

            try {
                _cards.Remove((TCard)value);
            }
            catch (InvalidCastException ex) {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        public void RemoveAt(int index) => _cards.RemoveAt(index);

        object IList.this[int index] {
            get => _cards[index];
            set {
                if (value == null) {
                    throw new ArgumentNullException(nameof(value));
                }

                try {
                    _cards[index] = (TCard)value;
                }
                catch (InvalidCastException ex) {
                    throw new ArgumentException(ex.Message, ex);
                }
            }
        }

        public TCard this[int index] => _cards[index];
    }
}