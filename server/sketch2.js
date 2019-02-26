let x_val = [];
let y_val = [];
let m;
let b;
let c;
const optimizer = tf.train.sgd(0.5);
function setup() {
  createCanvas(500, 500);
  frameRate(8);
  m = tf.variable(tf.scalar(1));
  b = tf.variable(tf.scalar(1));
  c = tf.variable(tf.scalar(1));
}
function mousePressed() {
  let x = map(mouseX, 0, width, 0, 1);
  let y = map(mouseY, 0, height, 1, 0);
  x_val.push(x);
  y_val.push(y);
}
function Predict(xs) {
  const x_tf = tf.tensor1d(xs)
  let y_tf = x_tf.square().mul(m);
  y_tf=y_tf.add(x_tf.mul(b));
  y_tf=y_tf.add(c);
  return y_tf
}
function loss(pred, labels) {
  return pred.sub(labels).square().mean();
}
function draw() {
  tf.tidy(()=>{if (x_val.length > 0) {
    let y_tf = tf.tensor1d(y_val);
    optimizer.minimize(()=>loss(Predict(x_val), y_tf));
  }});
  background(0);
  stroke(255);
  strokeWeight(4);
  for (var i in x_val) {
    let px = map(x_val[i], 0, 1, 0, width);
    let py = map(y_val[i], 0, 1, height, 0);
    point(px, py);
  }
  tf.tidy(()=>{if (x_val.length > 0) {
    let a=(Predict([0,1])).dataSync();
    let x1_point=map(0, 0, 1, 0, width);
    let x2_point=map(1, 0, 1, 0, width);
    let y1_point = map(a[0], 0, 1, height, 0);
    let y2_point = map(a[1], 0, 1, height, 0);
    strokeWeight(3);
    line(x1_point,y1_point,x2_point,y2_point);
  }});
}