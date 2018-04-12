var gulp = require("gulp"),
    less = require("gulp-less"),
    cleanCSS = require('gulp-clean-css');

gulp.task('default', ['less'], function () {
    minifyCss();
});

gulp.task("less", function () {
    return gulp.src('Styles/site.less')
        .pipe(less())
        .pipe(gulp.dest('wwwroot/css'));
});

gulp.task('minify-css', () => minifyCss());

gulp.task('watch', ['default'], function () {
    gulp.watch('Styles/site.less', ['default']);
});

function minifyCss() {
    return gulp.src('wwwroot/css/*.css')
        .pipe(cleanCSS({ compatibility: 'ie8' }))
        .pipe(gulp.dest('wwwroot/css'));
}

