# (Check this)Category theory -> [look for Group-like structures image](https://en.wikipedia.org/wiki/Semigroup)

# Code should be readible
*Michael Fathers* : "any fool can write code that a computer can understand. Good programmers write code that human can understand."  

Items in mind 7 +-2 (keep tracking)
chunk = grouping (if there's more elements that we need keep tracking in our head we start grouping things in one chunk)

# Prodcutivity
3 constraints of "productivity":
* resources = devs ;) + money
* time
* ??
It's hard to measure productivity. And even though maybe it is impossible.   
Example of pointless measurement is : `lines of code`
[Article about productivity tools](http://blog.ploeh.dk/2013/02/04/BewareofProductivityTools/)

# Definition of **abstraction**:  
* *Uncle Bob* : "the amplification of the essential and the elemination of irrelevant"
* *Dijkstra* : "Being abstract is something profoundly different from being vague … The purpose of abstraction is not to be vague, but to create a new semantic level in which one can be absolutely precise."

Encapsulation is broken when you need to read decompiled code!

CQS principle

reusable abstractions, design patterns

Closure of operations (DDD, Eric Evans)

# Composite -> monoids
Composite - you can use this pattern when return types are *monoids* [synonym: combinable, reduciblie](it's not monads!) 
Watch return types of interface

Referential transparancy = Type arguments taken into operation returns the same type 1+1=2; number+number=number

ethymology of monoid (from greek)
monoid = mono (alone/single) + iod (-like) = onelike

Example of monoid: composition pattern, SQL COALESCE

This code is not applicable to composite pattern:
> `Customer ICompositRepository::Read(Guid id)`   
But this can be:
> `First<Customer> ICompositRepository::Read(Guid id)`   

First<T> will return Left-most non-empty value. This is implementation of F# `option` and in Haskell `maybe`?

We change null with Identity (it is accumulator value)

## What compose Monoids:
* binary operations 
* identity
* keep chaining
* associative [explanation](https://www.mathsisfun.com/associative-commutative-distributive.html)

Monoid is binary associative opeartion with identity

How to identify `identity`:
* `id <> foo = foo`
* `foo <> id = foo`

Identity is associated with operation!
string Concatenation is monoid not collection as self! In .Net collection is monoid, but just FINITE collection, so infinite IEnumerable isn't monoid

[Introduce parameter object - pattern](https://refactoring.com/catalog/introduceParameterObject.html)


Even though if some types aren't not monoids, you can transform them to monoids and do operations on monoids

We can create `null object` when it behaves like monoid.

foldable - specific of catmorphism?
LINQ aggregate will throw exception for this signature: (`new int[0].Aggregate(Math.Max)`)
when using accumulator it doesn't (`new int[0].Aggregate(0,Math.Max)`)
Implementation with accumulator (seed)
```
[__DynamicallyInvokable]
    public static TAccumulate Aggregate<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      if (func == null)
        throw Error.ArgumentNull(nameof (func));
      TAccumulate accumulate = seed;
      foreach (TSource source1 in source)
        accumulate = func(accumulate, source1);
      return accumulate;
    }
```    	
	
chain of responsibility - design pattern - example of getting icon from Gravatar, then get from db and get default implementation
