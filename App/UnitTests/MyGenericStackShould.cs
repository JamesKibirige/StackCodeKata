using FluentAssertions;
using StackCodeKata;
using System;
using Xunit;

namespace UnitTests
{
    public class MyGenericStackShould
    {
        [Fact]
        public void CanCreateStackObject_ReturnsInstanceOfStack()
        {
            var stack = new MyGenericStack<string>(5);

            stack.Should().NotBeNull();
        }

        [Fact]
        public void NewStack_ShouldBeEmpty_StackSizeZero()
        {
            var stack = new MyGenericStack<string>(5);

            stack.Size.Should().Be(0);
        }

        [Fact]
        public void Push_FirstElement_StackSizeOne()
        {
            var stack = new MyGenericStack<string>(5);

            stack.Push("Cat");

            stack.Size.Should().Be(1);
        }

        [Fact]
        public void Pop_AfterFirstPush_StackSizeZero()
        {
            var stack = new MyGenericStack<string>(5);

            stack.Push("Cat");
            stack.Pop();

            stack.Size.Should().Be(0);
        }

        [Fact]
        public void Push_OverLimit_ThrowsOverFlowException()
        {
            const int limit = 1;
            var stack = new MyGenericStack<string>(limit);

            stack.Push("Cat");
            Action push = () => stack.Push("Dog");

            push.Should().Throw<OverflowException>();
        }

        [Fact]
        public void Pop_EmptyStack_ThrowsException()
        {
            var stack = new MyGenericStack<string>(1);

            Action pop = () => stack.Pop();

            pop.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void PushTwice_PopOnce_SizeOne()
        {
            var stack = new MyGenericStack<string>(2);

            stack.Push("Cat");
            stack.Push("Dog");
            stack.Pop();

            stack.Size.Should().Be(1);
        }

        [Fact]
        public void Push_PopLastValue_ReturnsLastValue()
        {
            var stack = new MyGenericStack<string>(2);

            stack.Push("Cat");
            var result = stack.Pop();

            result.Should().Be("Cat");
        }

        [Fact]
        public void PushCat_PushDog_PopDog_PopCat()
        {
            var stack = new MyGenericStack<string>(2);

            stack.Push("Cat");
            stack.Push("Dog");

            var firstresult = stack.Pop();
            var secondresult = stack.Pop();

            firstresult.Should().Be("Dog");
            secondresult.Should().Be("Cat");
        }

        [Fact]
        public void CreateStack_LimitLessThanO_ThrowsException()
        {
            Action create = () => { new MyGenericStack<string>(-1); };

            create.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Push_Limit0_ThrowsOverflowException()
        {
            const int limit = 0;
            var stack = new MyGenericStack<string>(limit);

            Action push = () => stack.Push("Cat");

            push.Should().Throw<OverflowException>();
        }

        [Fact]
        public void PushCat_PeekCat()
        {
            var stack = new MyGenericStack<string>(1);

            stack.Push("Cat");
            var result = stack.Peek();

            result.Should().Be("Cat");
        }

        [Fact]
        public void PushCat_PushDog_PeekDog()
        {
            var stack = new MyGenericStack<string>(2);

            stack.Push("Cat");
            stack.Push("Dog");
            var result = stack.Peek();

            result.Should().Be("Dog");
        }

        [Fact]
        public void Peek_EmptyStack_ThrowsException()
        {
            var stack = new MyGenericStack<string>(1);

            Action peek = () => stack.Peek();

            peek.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Peek_Limit0_ThrowsException()
        {
            const int limit = 0;
            var stack = new MyGenericStack<string>(limit);

            Action peek = () => stack.Peek();

            peek.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void PushCat_PushDog_FindCat_FindDog()
        {
            var stack = new MyGenericStack<string>(2);

            stack.Push("Cat");
            stack.Push("Dog");

            var cat = stack.Find("Cat");
            var dog = stack.Find("Dog");

            cat.Should().Be("Cat");
            dog.Should().Be("Dog");
        }

        [Fact]
        public void FindCat_CatNotExist_ReturnsNull()
        {
            var stack = new MyGenericStack<string>(1);

            stack.Push("Dog");

            var cat = stack.Find("Cat");

            cat.Should().BeNull();
        }
    }
}
