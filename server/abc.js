var a=(1-Math.sqrt(5))/2;
var b=(1+Math.sqrt(5))/2;
var c=Math.sqrt(5);
console.log(a);
console.log(b);
console.log(c);
for(let i=0;i<100;i++){
	var d=Math.pow(b,i)-Math.pow(a,i);
	d=d/c
	console.log(d);
}