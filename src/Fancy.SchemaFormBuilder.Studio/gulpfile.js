var gulp = require('gulp');
var uglify = require('gulp-uglify');
var concat  = require('gulp-concat');
var sourcemaps = require('gulp-sourcemaps');
var bower = require('gulp-bower');
 
gulp.task('bower', function() {
  return bower({ layout: 'byComponent'})
    .pipe(gulp.dest('wwwroot/lib'))
});

gulp.task('script', function() {
  return gulp
	.src('wwwroot/app/**/*.js')
	.pipe(sourcemaps.init())
	.pipe(concat('app.min.js'))
  //.pipe(uglify())
	.pipe(sourcemaps.write('./'))
  .pipe(gulp.dest('wwwroot'));
});

gulp.task('watch', function() {
  gulp.watch('wwwroot/app/**/*.js', ['script']);
});