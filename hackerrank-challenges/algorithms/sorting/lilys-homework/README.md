### Problem Statement

Whenever George asks Lily to hang out, she's busy doing homework. George wants to help her finish it faster, but he's in over his head! Can you help George understand Lily's homework so she can hang out with him?

### Problem Description

Consider an array of distinct integers, `arr`. George can swap any two elements of the array any number of times. An array is _beautiful_ if the sum of among is minimal.

Given the array `[7, 15, 12, 3]`, determine and return the minimum number of swaps that should be performed in order to make the array _beautiful_.

### Example

One minimal array is `[3, 7, 12, 15]`. To get there, George performed the following swaps:

```
| Swap      | Result                |
|-----------|------------------------|
| 3 7       | [3, 15, 12, 7]         |
| 7 15      | [3, 7, 12, 15]        |
```

It took `2` swaps to make the array beautiful. This is minimal among the choices of beautiful arrays possible.

### Function Description

Complete the `lilysHomework` function in the editor below.
```python
def lilysHomework(arr):
    # Your code here...
```

### Input Format

The first line contains a single integer, `n`, the number of elements in `arr`. The second line contains space-separated integers, `arr`.

### Constraints

*   1 ≤ n ≤ 10000

### Sample Input
```stdin
4
2 5 3 1
```

### Sample Output
```
2
```

### Explanation

Define `b` to be the beautiful reordering of `arr`. The sum of the absolute values of differences between its adjacent elements is minimal among all permutations and only two swaps (with and then with) were performed.