using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 *  A BoundedList is an Array which knows how many elements it has.  Like an
 *  Array, the capicity is completely fixed.  However, this class has the added
 *  feature that it knows how many non-null elements it contains.
 * 
 *  TODO implement IList when time allows
 */
public class BoundedList<T> : IEnumerable<T> {

/*  Constructor
 *  ==========================================================================*/
/**
 *  Instantiates a bounded list.
 *  @param cap The permanent capacity of the list.
 */
	public BoundedList(int cap) {
		this.count = 0;
		this.capacity = cap;
		this.items = new T[cap];
	}

/*  Access
 *  ==========================================================================*/
/**
 *  The number of elements currently in the list
 */
	public int Count {  get {  return this.count; } }

/**
 *  The maximum possible number of elements the list may contain
 */
	public int Capacity {  get {  return this.capacity; } }

/**
 *  Array access for the list
 */
	public T this[int key] {
		get {
			return items[key];
		}
		set {
			if(key == Count)
				Add(value);
			else if(key < Count)
				items[key] = value;
			else
				throw new System.Exception("Key " + key + " is beyond the Count of BoundedList");
		}
	}

/*  Public Methods
 *  ==========================================================================*/
/**
 *  Appends an element to the end of the list
 *  @param obj The object to add
 *  @throws Exception when adding an element would exceed capacity
 */
	public int Add(T obj) {
		if(Count < Capacity) {
			items[Count] = obj;
			++count;
			return count - 1;
		}
		else
			throw new System.Exception("BoundedList would exceed capacity after Add");
	}

/**
 *  Removes the given element from the list if possible.  This will not throw if
 *  the element does not exist.
 *  @param obj The element to remove
 */
	public void Remove(T obj) {
		int i = 0;
		while(i < Count && Object.ReferenceEquals(items[i], obj))
			++i;
		if(i < Count)
			RemoveAt(i);
	}

/**
 *  Removes the element at the given index.
 *  @param i The index.  Must be greater than 0 and less than Count
 */
	public void RemoveAt(int i) {
		if(i < 0 || i >= Count)
			throw new System.ArgumentOutOfRangeException("Index in Remove is out of bounds");
		while(i < Count - 1) {
			items[i] = items[i + 1];
			++i;
		}
		items[count--] = default(T);
	}

/*  IEnumerable Interface
 *  ==========================================================================*/
	public IEnumerator<T> GetEnumerator() {
		for(int i = 0; i < Count; ++i)
			yield return items[i];
	}

	IEnumerator IEnumerable.GetEnumerator() {
		return GetEnumerator();
	}

/*  Private Members
 *  ==========================================================================*/
	private int count;
	private int capacity;
	private T[] items;
}
