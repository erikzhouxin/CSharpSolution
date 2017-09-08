//往往json传过来的时间都是"/Date(1405056837780)/"
//转换需要的方法
String.prototype.ToString = function (format) {
	var dateTime = new Date(parseInt(this.substring(6, this.length - 2)));
	format = format.replace("yyyy", dateTime.getFullYear());
	format = format.replace("yy", dateTime.getFullYear().toString().substr(2));
	format = format.replace("MM", dateTime.getMonth() + 1)
	format = format.replace("dd", dateTime.getDate());
	format = format.replace("hh", dateTime.getHours());
	format = format.replace("mm", dateTime.getMinutes());
	format = format.replace("ss", dateTime.getSeconds());
	format = format.replace("ms", dateTime.getMilliseconds())
	return format;
};
//调用"/Date(1405056837780)/".ToString("yyyy年MM月dd日hh时mm分ss秒");