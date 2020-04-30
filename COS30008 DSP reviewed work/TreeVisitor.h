
// COS30008, Problem Set 7, 2019

#pragma once

#include <iostream>

template<class T>
class TreeVisitor
{
public:
	virtual ~TreeVisitor() {}	// virtual default destructor

								// default behavior
	virtual void preVisit(const T& aKey) const
	{}

	virtual void postVisit(const T& aKey) const
	{}

	virtual void inVisit(const T& aKey) const
	{}

	virtual void visit(const T& aKey) const
	{
		std::cout << aKey << " ";
	}
};

template<class T>
class PreOrderVisitor : public TreeVisitor<T>
{
public:

	// override pre-order behavior
	virtual void preVisit(const T& aKey) const
	{
		this->visit(aKey); 	// invoke default behavior
	}
};

template<class T>
class PostOrderVisitor : public TreeVisitor<T>
{
public:

	// override post-order behavior
	virtual void postVisit(const T& aKey) const
	{
		this->visit(aKey); 	// invoke default behavior
	}
};

template<class T>
class LeftLinearVisitor : public TreeVisitor<T>
{
public:

	virtual void visit(const T& aKey) const
	{
		std::cout << aKey;
	}

	virtual void preVisit(const T& aKey) const
	{
		std::cout << "[";
		visit(aKey);
	}

	virtual void postVisit(const T& aKey) const
	{
		std::cout << "]";
	}
};


/*
// COS30008, Problem Set 7, 2019

#pragma once

#include <iostream>

template<class T>
class TreeVisitor
{
public:
	virtual ~TreeVisitor() {}	// virtual default destructor

								// default behavior
	virtual void preVisit(const T& aKey) const
	{}

	virtual void postVisit(const T& aKey) const
	{}

	virtual void inVisit(const T& aKey) const
	{}

	virtual void visit(const T& aKey) const
	{
		std::cout << aKey << " ";
	}
};

template<class T>
class PreOrderVisitor : public TreeVisitor<T>
{
public:

	// override pre-order behavior
	virtual void preVisit(const T& aKey) const
	{
		this->visit(aKey); 	// invoke default behavior
	}
};

template<class T>
class PostOrderVisitor : public TreeVisitor<T>
{
public:

	// override post-order behavior
	virtual void postVisit(const T& aKey) const
	{
		this->visit(aKey); 	// invoke default behavior
	}
};

template<class T>                                                   // 2
class LeftLinearVisitor : public TreeVisitor<T>                     // 6
{
public:                                                             // 2

																	// override post-order behavior
	void postVisit(const T& aKey) const override                  // 4
	{
		std::cout << "]";                                           // 4
	}

	// override pre-order behavior
	void preVisit(const T& aKey) const override                   // 6
	{
		std::cout << "[" << aKey;                                   // 6/30
	}
};*/
