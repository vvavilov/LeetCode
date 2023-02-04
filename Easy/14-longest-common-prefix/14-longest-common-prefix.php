<?php

class Solution {

    /**
     * @param String[] $strs
     * @return String
     */
    
function longestCommonPrefix(array $strs) {
    if (empty($strs)) {
        return "";
    }
    if (count($strs) == 1) {
        return $strs[0];
    }
    sort($strs);
    $prefix = "";
    for ($i = 0; $i < strlen($strs[0]); $i++) {
        if ($strs[0][$i] == $strs[count($strs) - 1][$i]) {
            $prefix .= $strs[0][$i];
        } else {
            break;
        }
    }
    return $prefix;
}


}