static int BinarySearch(int[] arr, int target, int first, int last) {
    if (last < first) { return -1; }

    var mid = first + (last - first) / 2;

    if(arr[mid] == target) { return mid; }
    if(arr[mid] > target) { return BinarySearch(arr, target, first, mid - 1); }
    return BinarySearch(arr, target, mid + 1, last);
}

static int BinarySearchNonRecursive(int[] arr, int target) {
    var first = 0;
    var last = 0;

    while(first < last) {
        var mid = first + (last - first) / 2;
        if(arr[mid] == target) { return mid; }
        if(arr[mid] > target) { last = mid - 1; }
        if(arr[mid] < target) { first = mid + 1; }
    }

    return -1;
}
