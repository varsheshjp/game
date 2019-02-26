var r;
var a=200
var points = a;
var N = 1;
var f=2;
var x=1;
function setup() {
    createCanvas(800, 800);
    frameRate(f);
    r = (width / 2) - 20;
}
function getVector(index) {
    var angle = map(index % points, 0, points, 0, TWO_PI);
    var v = p5.Vector.fromAngle(angle + PI);
    v.mult(r);
    return v;
}
function draw() {
    background(0);
    translate(width / 2, height / 2);
    stroke(255);
    strokeWeight(1);
    smooth()
    noFill();
    N=N+x;
    console.log(N);
    for (var i = 0; i < points; i++) {
        var a = getVector(i);
        var b = getVector(i * N);
        line(a.x, a.y, b.x, b.y);
    }
}