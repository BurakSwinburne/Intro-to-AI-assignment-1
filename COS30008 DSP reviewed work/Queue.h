
// COS30008, Problem Set 6, 2019

#pragma once

#include "List.h"
#include <stdexcept>

template<class T>
class Queue
{
private:
	List<T> fElements;

public:
	bool isEmpty() const
	{
		return fElements.isEmpty();
	}

	int size() const
	{
		return fElements.size();
	}

	void enqueue(const T& aElement)
	{
		fElements.push_back(aElement);
	}

	void dequeue()
	{
		if (isEmpty())
			throw std::underflow_error("Queue empty.");

		fElements.remove(fElements[0]);
	}

	const T& top() const
	{
		if (isEmpty())
			throw std::underflow_error("Queue empty.");

		return fElements[0];
	}
};

