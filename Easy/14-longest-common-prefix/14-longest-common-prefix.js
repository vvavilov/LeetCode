/**
 * @param {string[]} strs
 * @return {string}
 */
var longestCommonPrefix = function(strs) {
    if (strs.length === 0) {
        return '';
    }
    if (strs.length === 1) {
        return strs[0];
    }
    strs.sort();
    let prefix = '';
    for (let i = 0; i < strs[0].length; i++) {
        if (strs[0][i] === strs[strs.length - 1][i]) {
            prefix += strs[0][i];
        } else {
            break;
        }
    }
    return prefix;
};