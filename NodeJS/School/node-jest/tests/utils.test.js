const utils = require('../utils')

test('rounds 3.1415927 to 3.14', () => {
    expect(utils.Round(3.1415927)).toBe(3.14)
})

test('Remove 1 from [1, 2, 3, 4]', () => {
    expect(utils.RemoveFirst([1, 2, 3, 4])).toStrictEqual([2, 3, 4])
})