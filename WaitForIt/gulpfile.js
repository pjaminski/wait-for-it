var gulp = require("gulp"),
    less = require("gulp-less"),
    cleanCSS = require('gulp-clean-css');

gulp.task("less", function () {
    return gulp.src('Styles/site.less')
        .pipe(less())
        .pipe(gulp.dest('wwwroot/css'));
});

gulp.task('minify-css', function () {
    return gulp.src('wwwroot/css/*.css')
        .pipe(cleanCSS({ compatibility: 'ie8' }))
        .pipe(gulp.dest('wwwroot/css'));
});