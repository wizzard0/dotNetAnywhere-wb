nlog = log;
log =function(x){ nlog.apply(x);}

if (PersistentRoot[1]) PersistentRoot[1]('omg');
log("persistent root[0] is: " + PersistentRoot[0]);
log("test");
var xf = function (s) { log('fun>' + s); }
xf('run');
PersistentRoot[0] = 5;
PersistentRoot[1] = xf;

alert=alert2 = log;

alert("ok");
var mf = metafunc("function () { alert(\"функция вызвана\"); }")
alert(mf.toString());
//alert(String(mf));
var obj = { 1: 2,2:[1,2,3,4,5], foobar: mf, boofar: function(){alert("5");} };
obj.foobar();
obj.boofar();
var q = JSON.stringify(obj);
alert(q);
alert("====");
var obj2 = JSON.parse(q);
try {
    obj2.foobar();
}
catch (e) { 
    alert("no foobar");
}
try {
alert(obj2.boofar());
}
catch (e){
    alert("no boofar");
}
alert(JSON.stringify(obj2));
alert("end");
return;
alert("\r\nDumping objects");

//var known_bugs = [];
var known_bugs = ['null', 'Object', 'Function', 'Array', 'Boolean', 'Date', 'Error', 'EvalError',
 'RangeError', 'ReferenceError', 'SyntaxError', 'TypeError', 'URIError', 'Math', 'Number', 'RegExp',
 'String', 'NaN', 'Infinity', 'undefined', 'this', 'eval', 'parseInt', 'parseFloat', 'isNaN',
  'isFinite', 'decodeURI', 'encodeURI', 'decodeURIComponent', 'encodeURIComponent', 'ToBoolean',
   'ToByte', 'ToChar', 'ToDateTime', 'ToDecimal', 'ToDouble', 'ToInt16', 'ToInt32', 'ToInt64',
    'ToSByte', 'ToSingle', 'ToString', 'ToUInt16', 'ToUInt32', 'ToUInt64',"globals"];

// alert(globals === this); //False
for (var q in globals) {
    var known = false;
    for (var kb in known_bugs) if (known_bugs[kb] === q) { known = true; break; }
    if (known) continue;
    alert2("\r\n"+q+" = ");
    try {
        alert(JSON.stringify(globals[q]));
    } catch (e) { alert("Exception: "+e); }
}
alert("DONE!");
