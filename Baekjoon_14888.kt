private var numCnt = 0
private val nums = mutableListOf<Int>()
private val operators = IntArray(4)
private var max = Int.MIN_VALUE
private var min = Int.MAX_VALUE

fun main() {
    input()
    calculation(nums[0], 1)
    output()
}

private fun input() {
    numCnt = readln().toInt()
    readln().split(" ").map { it.toInt() }.forEach { nums.add(it) }
    readln().split(" ").map { it.toInt() }.forEachIndexed { index, cnt ->
        operators[index] = cnt
    }
}

private fun calculation(total: Int, idx: Int) {
    if(idx == numCnt) {
        if(total < min) min = total
        if(total > max) max = total

        return
    }

    for(i in 0 until 4) {
        if(operators[i] > 0) {
            operators[i]--

            when(i) {
                0 -> calculation(total + nums[idx], idx + 1)
                1 -> calculation(total - nums[idx], idx + 1)
                2 -> calculation(total * nums[idx], idx + 1)
                3 -> calculation(total / nums[idx], idx + 1)
            }

            operators[i]++
        }
    }
}

private fun output() {
    println(max)
    println(min)
}