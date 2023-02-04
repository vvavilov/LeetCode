# @param {String[]} strs
# @return {String}
def longest_common_prefix(strs)
    return "" if strs.empty?
    return strs[0] if strs.length == 1
    strs.sort!
    prefix = ""
    (0...strs[0].length).each do |i|
        if strs[0][i] == strs[-1][i]
            prefix += strs[0][i]
        else
            break
        end
    end
    prefix
end