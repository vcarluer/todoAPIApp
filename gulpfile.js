var gulp = require('gulp')
var shell = require('gulp-shell')
var watch = require('gulp-watch')

var paths = {
	dotnet: ['./**/*.cs']
}

gulp.task('build', shell.task(['dotnet build']))
gulp.task('default', function() {
	gulp.watch('./**/*.cs', ['build'])
})
