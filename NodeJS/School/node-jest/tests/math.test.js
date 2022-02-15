const math = require('../math')

test('adds 1 + 2 to equal 3', () => {
    expect(math.plus(1, 2)).toBe(3);
    // const result = math.plus(1,2)
    // if (result != 3)
    //     throw new Error("Test failed.")
});

test('multiplies 3 * 4 to equal 12', () => {
    expect(math.mul(3, 4)).toBe(12)
})