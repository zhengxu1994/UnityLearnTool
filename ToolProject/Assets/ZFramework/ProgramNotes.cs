//记录项目中遇到的问题
//1.特效在一开始播放的时候闪烁了一下，这个问题大多是因为特效的Animator的CullMode参数设置错误导致的
//CullMode :  AlwaysAnimate(总是在播放动画，即使对象在屏幕外)
//CullUpdateTransforms（当渲染器不可见时，转换的重新定位、IK和写入被禁用）
//CullComplete （当渲染器不可见时，动画是完全禁用的。）
//应该使用第三个参数，当特效被隐藏后就应该完全禁用动画。