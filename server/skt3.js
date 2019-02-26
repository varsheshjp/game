let x_val = [];
let y_val = [];
let m;
let b;
const optimizer = tf.train.sgd(0.5);
function setup() {
  createCanvas(500, 500);
  frameRate(8);
  m = tf.variable(tf.scalar(1));
  b = tf.variable(tf.scalar(1));
}
function mousePressed() {
  let x = map(mouseX, 0, width, 0, 1);
  let y = map(mouseY, 0, height, 1, 0);
  x_val.push(x);
  y_val.push(y);
}
function Predict(xs) {
  const x_tf = tf.tensor1d(xs)
  let y_tf = x_tf.mul(m);
  y_tf=y_tf.add(b);
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
    let a=(Predict([0,0.25,0.5,0.75,1])).dataSync();
    strokeWeight(3);
    let x1_point=map(0, 0, 1, 0, width);
    let x2_point=map(0.25, 0, 1, 0, width);
    let x3_point=map(0.5, 0, 1, 0, width);
    let x4_point=map(0.75, 0, 1, 0, width);
    let x5_point=map(1, 0, 1, 0, width);
    let y1_point = map(a[0], 0, 1, height, 0);
    let y2_point = map(a[1], 0, 1, height, 0);
    let y3_point = map(a[2], 0, 1, height, 0);
    let y4_point = map(a[3], 0, 1, height, 0);
    let y5_point = map(a[4], 0, 1, height, 0);
    
    line(x1_point,y1_point,x2_point,y2_point);
    line(x2_point,y2_point,x3_point,y3_point);
    line(x3_point,y3_point,x4_point,y4_point);
    line(x4_point,y4_point,x5_point,y5_point);
    

  }});
}