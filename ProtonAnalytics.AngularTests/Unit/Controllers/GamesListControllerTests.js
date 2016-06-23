test("exponential math", function () {
    var res = Math.pow(2, 3);
    equal(res, 8, "2^3 = 8");
});

test("impossible division", function () {
    var res = 1 / 0;
    equal(res, 0);
});