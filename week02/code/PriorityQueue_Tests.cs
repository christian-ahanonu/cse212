using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities and ensure Dequeue returns the highest priority item.
    // Expected Result: Dequeue should return "HighPriorityItem" first, followed by "MediumPriorityItem", then "LowPriorityItem".
    // Defect(s) Found: Dequeue returned "MediumPriorityItem" instead of "HighPriorityItem", meaning the highest priority item isn't being correctly identified.
    public void TestPriorityQueue_DequeueHighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("LowPriorityItem", 1);
        priorityQueue.Enqueue("MediumPriorityItem", 5);
        priorityQueue.Enqueue("HighPriorityItem", 10);

        var firstDequeue = priorityQueue.Dequeue();
        Assert.AreEqual("HighPriorityItem", firstDequeue, "The first dequeued item should be 'HighPriorityItem'.");

        var secondDequeue = priorityQueue.Dequeue();
        Assert.AreEqual("MediumPriorityItem", secondDequeue, "The second dequeued item should be 'MediumPriorityItem'.");

        var thirdDequeue = priorityQueue.Dequeue();
        Assert.AreEqual("LowPriorityItem", thirdDequeue, "The third dequeued item should be 'LowPriorityItem'.");
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same highest priority and ensure Dequeue follows FIFO order.
    // Expected Result: Dequeue should return "FirstHighPriorityItem" first, then "SecondHighPriorityItem".
    // Defect(s) Found: Dequeue returned "SecondHighPriorityItem" instead of "FirstHighPriorityItem", so the first enqueued item with the same priority wasn't dequeued first.
    public void TestPriorityQueue_DequeueFIFOWithSamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("FirstHighPriorityItem", 10);
        priorityQueue.Enqueue("SecondHighPriorityItem", 10);
        priorityQueue.Enqueue("LowPriorityItem", 1);

        var firstDequeue = priorityQueue.Dequeue();
        Assert.AreEqual("FirstHighPriorityItem", firstDequeue, "The first dequeued item should be 'FirstHighPriorityItem'.");

        var secondDequeue = priorityQueue.Dequeue();
        Assert.AreEqual("SecondHighPriorityItem", secondDequeue, "The second dequeued item should be 'SecondHighPriorityItem'.");

        var thirdDequeue = priorityQueue.Dequeue();
        Assert.AreEqual("LowPriorityItem", thirdDequeue, "The third dequeued item should be 'LowPriorityItem'.");
    }

    [TestMethod]
    // Scenario: Enqueue and Dequeue items to ensure the queue maintains correct order after multiple operations.
    // Expected Result: Dequeue should consistently return the highest priority items in correct order.
    // Defect(s) Found: Dequeue returned "MediumPriorityItem" instead of "HighPriorityItem" after multiple operations, indicating issues with maintaining priority order.
    public void TestPriorityQueue_MultipleOperations()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("LowPriorityItem", 1);
        priorityQueue.Enqueue("MediumPriorityItem", 5);
        priorityQueue.Enqueue("HighPriorityItem", 10);

        var firstDequeue = priorityQueue.Dequeue();
        Assert.AreEqual("HighPriorityItem", firstDequeue, "The first dequeued item should be 'HighPriorityItem'.");

        priorityQueue.Enqueue("AnotherHighPriorityItem", 10);

        var secondDequeue = priorityQueue.Dequeue();
        Assert.AreEqual("AnotherHighPriorityItem", secondDequeue, "The second dequeued item should be 'AnotherHighPriorityItem'.");

        var thirdDequeue = priorityQueue.Dequeue();
        Assert.AreEqual("MediumPriorityItem", thirdDequeue, "The third dequeued item should be 'MediumPriorityItem'.");

        var fourthDequeue = priorityQueue.Dequeue();
        Assert.AreEqual("LowPriorityItem", fourthDequeue, "The fourth dequeued item should be 'LowPriorityItem'.");
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue should throw an InvalidOperationException.
    // Expected Result: An InvalidOperationException is thrown with the message "The queue is empty.".
    // Defect(s) Found: No defects found. The Dequeue method correctly throws an exception when the queue is empty.
    public void TestPriorityQueue_DequeueEmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected InvalidOperationException was not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message, "Exception message should be 'The queue is empty.'");
        }
        catch (Exception ex)
        {
            Assert.Fail($"Unexpected exception type: {ex.GetType()} with message: {ex.Message}");
        }
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with varying priorities and ensure Dequeue always returns the highest priority.
    // Expected Result: Dequeue should return items in the order: "Item3", "Item2", "Item1".
    // Defect(s) Found: Dequeue returned "Item2" instead of "Item3", meaning the highest priority item wasn't correctly identified.
    public void TestPriorityQueue_VaryingPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 3);
        priorityQueue.Enqueue("Item2", 7);
        priorityQueue.Enqueue("Item3", 10);

        var firstDequeue = priorityQueue.Dequeue();
        Assert.AreEqual("Item3", firstDequeue, "The first dequeued item should be 'Item3'.");

        var secondDequeue = priorityQueue.Dequeue();
        Assert.AreEqual("Item2", secondDequeue, "The second dequeued item should be 'Item2'.");

        var thirdDequeue = priorityQueue.Dequeue();
        Assert.AreEqual("Item1", thirdDequeue, "The third dequeued item should be 'Item1'.");
    }

    [TestMethod]
    // Scenario: Enqueue items with the same priority and ensure Dequeue follows FIFO order.
    // Expected Result: Dequeue should return "Alpha" first, then "Beta".
    // Defect(s) Found: Dequeue returned "Beta" before "Alpha", so FIFO order for same priority items wasn't maintained.
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Alpha", 5);
        priorityQueue.Enqueue("Beta", 5);

        var firstDequeue = priorityQueue.Dequeue();
        Assert.AreEqual("Alpha", firstDequeue, "The first dequeued item should be 'Alpha'.");

        var secondDequeue = priorityQueue.Dequeue();
        Assert.AreEqual("Beta", secondDequeue, "The second dequeued item should be 'Beta'.");
    }

    [TestMethod]
    // Scenario: Enqueue items with negative and zero priorities to ensure they are treated correctly.
    // Expected Result: Dequeue should return "PositivePriorityItem" first, then "ZeroPriorityItem", then "NegativePriorityItem".
    // Defect(s) Found: Dequeue returned "ZeroPriorityItem" instead of "PositivePriorityItem", meaning zero and negative priorities aren't handled correctly.
    public void TestPriorityQueue_NegativeAndZeroPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("ZeroPriorityItem", 0);
        priorityQueue.Enqueue("NegativePriorityItem", -5);
        priorityQueue.Enqueue("PositivePriorityItem", 5);

        var firstDequeue = priorityQueue.Dequeue();
        Assert.AreEqual("PositivePriorityItem", firstDequeue, "The first dequeued item should be 'PositivePriorityItem'.");

        var secondDequeue = priorityQueue.Dequeue();
        Assert.AreEqual("ZeroPriorityItem", secondDequeue, "The second dequeued item should be 'ZeroPriorityItem'.");

        var thirdDequeue = priorityQueue.Dequeue();
        Assert.AreEqual("NegativePriorityItem", thirdDequeue, "The third dequeued item should be 'NegativePriorityItem'.");
    }

    [TestMethod]
    // Scenario: Enqueue multiple items, some with the same priority, then Dequeue all and verify the order.
    // Expected Result: Items with higher priority are dequeued first; among same priority, FIFO order is maintained.
    // Defect(s) Found: Dequeue returned "ItemC" before "ItemA", breaking the FIFO order for items with the same priority.
    public void TestPriorityQueue_MultipleSamePriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("ItemA", 4);
        priorityQueue.Enqueue("ItemB", 4);
        priorityQueue.Enqueue("ItemC", 4);
        priorityQueue.Enqueue("ItemD", 2);

        var firstDequeue = priorityQueue.Dequeue();
        Assert.AreEqual("ItemA", firstDequeue, "The first dequeued item should be 'ItemA'.");

        var secondDequeue = priorityQueue.Dequeue();
        Assert.AreEqual("ItemB", secondDequeue, "The second dequeued item should be 'ItemB'.");

        var thirdDequeue = priorityQueue.Dequeue();
        Assert.AreEqual("ItemC", thirdDequeue, "The third dequeued item should be 'ItemC'.");

        var fourthDequeue = priorityQueue.Dequeue();
        Assert.AreEqual("ItemD", fourthDequeue, "The fourth dequeued item should be 'ItemD'.");
    }
}