(self.webpackChunk_N_E=self.webpackChunk_N_E||[]).push([[7045],{47283:function(e,t,r){"use strict";r.d(t,{Wz:function(){return a},Uh:function(){return c},kC:function(){return d}});var n=r(85893),i=r(67294),s=r(58677),o=r(82177);const a={magnetList:"116ae929826d1fd3",control:"95d42e19c24b03e7",variant1:"c44b726edf25a662",variant2:"15bc93f5a1ccbb65"},l=(0,i.createContext)(null),c=({children:e})=>{const t=(()=>{const{requestUri:e}=(0,s.bp)(),{variant:t}=(0,o.vl)(e);return t})();return window.akamaiVariant=t,(0,n.jsx)(l.Provider,{value:t,children:e})},{Consumer:u}=l;function d(){return(0,i.useContext)(l)}},7106:function(e,t,r){"use strict";r.d(t,{rZ:function(){return l},II:function(){return d},aq:function(){return f}});var n=r(85893),i=r(26265),s=r(67294);function o(e,t){var r=Object.keys(e);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(e);t&&(n=n.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),r.push.apply(r,n)}return r}function a(e){for(var t=1;t<arguments.length;t++){var r=null!=arguments[t]?arguments[t]:{};t%2?o(Object(r),!0).forEach((function(t){(0,i.Z)(e,t,r[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(r)):o(Object(r)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(r,t))}))}return e}const l={realtimeStaging:"MnFM6zTST2CUtNgNv8Ll2A",realtimeProd:"7K9oUCtpTuaBmLeArwPGkA",testABComponent:"hpEtoOD9R0abl2McqYgMdg",operationRunwayMobileStaging:"ZnzRIMMGRK6V8AAiZ9Ek1A",operationRunwayMobileProd:"SV-ALDIJQmOgPFcT6A7OCg",operationRunwayStaging:"owYmnynoRs-_qQR265epdg",operationRunwayProd:"lNW28w1AR4y_5uA2iv698Q",dianomiStaging:"P-N1wtgtSM-bN8vwjK6ZTg",dianomiProd:"y8RdCAvgRc2uVZ4PfW1NkQ",videoPlayButtonStaging:"OCSspvwNRzm7JatBcpAqKA",videoPlayButtonProd:"4Ud7eLGHRbyc3Sr8MOh0Tw"},c=e=>{const{0:t,1:r}=(0,s.useState)({});const n=(0,s.useCallback)(((e,t)=>{r((r=>a(a({},r),{},{[t]:e})))}),[]),i=(0,s.useCallback)((e=>{!function(){window.dataLayer&&window.dataLayer.push(arguments)}("event","optimize.callback",{name:e,callback:n})}),[n]);return(0,s.useEffect)((()=>{e.forEach((e=>i(e)))}),[e,i]),t},u=(0,s.createContext)({variants:{}}),d=({ids:e,children:t})=>{const r=c(e);return(0,n.jsx)(u.Provider,{value:{variants:r},children:t})},{Consumer:p}=u;function f(e){return(0,s.useContext)(u).variants[e]}},42447:function(e,t,r){"use strict";r.r(t);var n=r(85893);r(67294);t.default=({content:e,className:t})=>(0,n.jsx)("div",{className:`${t} raw-html`,"data-qa":"raw-html",children:(0,n.jsx)("div",{dangerouslySetInnerHTML:{__html:e}})})},23962:function(e,t,r){"use strict";r.d(t,{ik:function(){return y},ZP:function(){return O},GS:function(){return v}});var n=r(26265),i=r(85893),s=(r(67294),r(29208)),o=r.n(s),a=r(78297),l=r(76768),c=r(36916),u=r(4201);function d(e,t){var r=Object.keys(e);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(e);t&&(n=n.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),r.push.apply(r,n)}return r}function p(e){for(var t=1;t<arguments.length;t++){var r=null!=arguments[t]?arguments[t]:{};t%2?d(Object(r),!0).forEach((function(t){(0,n.Z)(e,t,r[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(r)):d(Object(r)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(r,t))}))}return e}var f=({element:{width:e,height:t,url:r,alt:n,caption:s,additional_properties:o},imgProps:{imgClassName:a="w-100 mw-100 h-auto",resizeUrl:c=!0}})=>{const d=n||s||l.BE,f=o&&o.placement_width?{w:o.placement_width.replace("px","")}:{w:e,h:t},m=p({width:e,height:t,src:c?(0,u.ZP)(r,f):r},{className:a,alt:d});return(0,i.jsx)("img",p({},m))},m=r(56582),h=r(22527),g=r(3373);function b(e,t){var r=Object.keys(e);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(e);t&&(n=n.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),r.push.apply(r,n)}return r}function w(e){for(var t=1;t<arguments.length;t++){var r=null!=arguments[t]?arguments[t]:{};t%2?b(Object(r),!0).forEach((function(t){(0,n.Z)(e,t,r[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(r)):b(Object(r)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(r,t))}))}return e}function y({element:e,imgProps:{separator:t="|",showCredits:r=!0,captionClassName:n,creditsClassName:s,caption:a}}){const l=o()(e,"credits.by"),c=l&&l.map((e=>e.byline)).join(` ${t} `)||"",u=o()(e,"credits.affiliation"),d=u&&u.map((e=>e.name)).join(` ${t} `)||"",p=r&&`${c}${c&&d&&` ${t} `}${d}`;return(a||p)&&(0,i.jsxs)("figcaption",{className:n,children:[a,p&&(0,i.jsx)("span",{className:s,children:p})]})||null}const v=e=>{let t=[{w:400,preset:"440"},{w:540,preset:"540"},{w:691,preset:"691"},{w:767,preset:"small"},{w:916,preset:"916"}],r=[{maxWidths:[440,440]}];if(e){const e=[{preset:"large",w:a.lg},{preset:"960",w:"960"},{preset:"medium",w:a.md},{url:"860",w:860}],n=[{maxWidths:[a.sm,a.sm]},{maxWidths:[768,691]},{minWidths:[a.md,860]},{minWidths:[a.lg,a.lg]}];t=[...t,...e],r=[...r,...n]}else{const e=[{maxWidths:[600,691]},{maxWidths:[768,691]},{minWidths:[769],maxWidths:[1023,960]},{minWidths:[1024],maxWidths:[1299,530]},{minWidths:[1300],maxWidths:[a.lg-1,691]},{minWidths:[a.lg,916]}];r=[...r,...e]}return r.push({finalWidth:440}),{widthsAndPresets:t,sizesConfig:(0,l.V3)(r)}},j={articleProperties:{isCenteredLayout:!1,articleType:"front"}};var O=function(e){var t,r;const{articleProperties:{articleType:n="standard",isCenteredLayout:s=!1,useGrid:o=!1}}=(0,g.$Y)()||j,{isFullWidth:a=!1,isGroup:u=!1,hasFigCaption:d=!0,noBleedMobile:p=!1,isFullBleed:b=!1,isSideBySide:O=!1,sideBySideWidth:P,sideBySideHeight:x,element:C,captionClasses:A,imgProps:_=w({},(0,l.Jd)({articleType:n,el:C,isCenteredLayout:s,isGroup:u,isGallery:null,ignoreDimensions:null,noBleedMobile:p,isFullBleed:b,isSideBySide:O,captionClasses:A,useGrid:o})),className:S=""}=e;let E=d;const k=(0,h.Z)(),N=null===(t=C.additional_properties)||void 0===t?void 0:t.media_size,D={small:{width:"50%"},medium:{width:"100%",maxWidth:700},large:{width:"180%",maxWidth:1e3},"full-bleed":{maxWidth:1600,width:"100%",marginLeft:"auto",marginRight:"auto"}},B="fixed"===_.layout||3===C.slotNum,W={className:`overflow-hidden relative hide-for-print center ${S||_.className}`};let Z;s&&!C.alignment&&k&&(Z=D[N]),null!==(0,c.lK)(C)&&(W.style=(0,c.cX)(C));const{widthsAndPresets:R,sizesConfig:$}=v(a);let{width:I,height:q}=((e,t=!1)=>{if(t)return{};const r=(0,c._G)(e),n=(0,c.dP)(e,r);return(0,c.tf)(n,e)})(C,_.isFullScreen);P&&x&&(I=P,q=x),("graphic"===(null===C||void 0===C?void 0:C.image_type)&&"staff"===(null===C||void 0===C||null===(r=C.distributor)||void 0===r?void 0:r.category)||""===(null===C||void 0===C?void 0:C.credits_caption_display))&&(E=!1);const z={element:w(w({},C),{},{width:I,height:q}),imgProps:w({},_),widthsAndPresets:R,sizesConfig:$,isSideBySide:O,isCenteredLayout:s},L={element:C,imgProps:w({},_)};return(0,i.jsxs)("figure",w(w({},W),{},{style:w({},Z),children:[B?(0,i.jsx)(f,w({},z)):(0,i.jsx)(m.Z,w({},z)),E&&(0,i.jsx)(y,w({},L))]}))}},95967:function(e,t,r){"use strict";var n=r(26265),i=r(85893),s=r(38347),o=(r(67294),r(83872));function a(e,t){var r=Object.keys(e);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(e);t&&(n=n.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),r.push.apply(r,n)}return r}function l(e){for(var t=1;t<arguments.length;t++){var r=null!=arguments[t]?arguments[t]:{};t%2?a(Object(r),!0).forEach((function(t){(0,n.Z)(e,t,r[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(r)):a(Object(r)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(r,t))}))}return e}const c=e=>{let{eager:t,children:r}=e,n=(0,s.Z)(e,["eager","children"]);return t?r:(0,i.jsx)(o.Z,l(l({},n),{},{children:r}))};t.Z=c,c.defaultProps={renderPlaceholder:e=>(0,i.jsx)("div",{ref:e}),eager:!1,offsetTop:300,offsetBottom:300}},3642:function(e,t,r){"use strict";r.r(t),r.d(t,{default:function(){return w}});var n=r(85893),i=r(26265),s=r(67294),o=r(95967),a=r(17974),l=r(38903),c=r(73768),u=r(34022);var d=e=>{const{caption:t,squareVid:r,verticalVid:i}=e;return(0,n.jsx)(s.Fragment,{children:t&&(0,n.jsx)("figcaption",{className:(0,u.getClasses)("mt-xs mr-auto-ns ml-auto-ns left gray-dark font--subhead font-xxxs",{"ml-gutter mr-gutter":!i&&!r,"square-vertical-video":i||r}),"data-qa":"video-caption",children:t})})},p=r(4201),f=r(46519),m=r(43386);function h(e,t){var r=Object.keys(e);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(e);t&&(n=n.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),r.push.apply(r,n)}return r}function g(e){for(var t=1;t<arguments.length;t++){var r=null!=arguments[t]?arguments[t]:{};t%2?h(Object(r),!0).forEach((function(t){(0,i.Z)(e,t,r[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(r)):h(Object(r)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(r,t))}))}return e}const b=e=>{const{videoConfig:{ads:t,allowShare:r,aspectRatio:i,autoinit:s,autoplay:u,caption:h,className:b,closedCaptions:w,customBtnText:y,includeDurationOrLive:v,isLive:j,muted:O,playthrough:P,showPreview:x,showPreview2:C,showTitle:A,playerType:_},alternateArt:S,videoData:E,uuid:k}=e,N={"data-org":"wapo","data-ads":t,"data-ad-bar":"1","data-allow-share":null!==r?r:"true","data-aspect-ratio":i,"data-autoinit":s||"false","data-autoplay":u||"false","data-blurb":"false","data-custom-btn-text":y,"data-duration-or-live":v||void 0===v||!1,"data-event400":x||C,"data-alternate-art":S,"data-live":j,"data-muted":O,"data-playthrough":P,"data-promo-video":!0,"data-preview":x,"data-preview2":C,"data-show-title":A,"data-subtitles":w,"data-uuid":k||E._id,"data-player-type":_,"data-viewport-autoplay":!(0,l.Rj)()&&void 0},D=(0,f.Z)(),B=(0,c.Bv)(i),W=(0,c.cp)(i);let Z,R;if(S){const e=(W||B)&&(0,c.$v)(D,i)||960;Z=(0,p.ZP)(encodeURIComponent(S),{w:e}),R=!0}else Z=c.gW,R=!1;const $=!1,I="rgb(245, 245, 245)",q=(0,n.jsx)(d,{caption:h,squareVid:B,verticalVid:W,aspectRatio:i});return(0,n.jsx)(o.Z,{offsetTop:300,offsetBottom:300,renderPlaceholder:e=>(0,n.jsx)("div",{ref:e,children:(0,n.jsx)("div",{"data-testid":"video-wrapper",children:(0,n.jsx)(a.U1,{wrapperRef:e,className:b,aspectRatio:i,placeholder:{image:Z,blur:R,resize:$,color:I},caption:q})})}),children:(0,n.jsx)("div",{"data-testid":"video-wrapper",children:(0,n.jsxs)(m.Z,{enabled:!0,children:[(0,n.jsxs)("videoPlayButton",{type:"optimize",children:[(0,n.jsx)("variant1",{children:(0,n.jsx)(a.nk,{uuid:k,video:E,className:b,aspectRatio:i,alternateArt:Z,placeholder:{image:Z,resize:$,color:I},caption:q,dataAttrs:g(g({},N),{},{"data-variant":1}),abTest:{reverseAnimation:!0,hideDuration:!0}})}),(0,n.jsx)("variant2",{children:(0,n.jsx)(a.nk,{uuid:k,video:E,className:b,aspectRatio:i,alternateArt:Z,placeholder:{image:Z,resize:$,color:I},caption:q,dataAttrs:g(g({},N),{},{"data-variant":2}),abTest:{reverseAnimation:!0,hideDuration:!1}})}),(0,n.jsx)("variant3",{children:(0,n.jsx)(a.nk,{uuid:k,video:E,className:b,aspectRatio:i,alternateArt:Z,placeholder:{image:Z,resize:$,color:I},caption:q,dataAttrs:g(g({},N),{},{"data-variant":3}),abTest:{reverseAnimation:!1,hideDuration:!0}})})]}),(0,n.jsx)("control",{children:(0,n.jsx)(a.nk,{uuid:k,video:E,className:b,aspectRatio:i,alternateArt:Z,placeholder:{image:Z,resize:$,color:I},caption:q,dataAttrs:g(g({},N),{},{"data-variant":0})})})]})})})};b.defaultProps={featureName:"null"};var w=b},73768:function(e,t,r){"use strict";r.d(t,{gW:function(){return s},n3:function(){return o},cp:function(){return a},Bv:function(){return l},$v:function(){return c}});var n=r(29208),i=r.n(n);const s="https://www.washingtonpost.com/player/prod/img/video-thumbnail-bg.png",o=(e,t)=>{const r=i()(e,"streams[0]");return t?r?parseFloat((r.width/r.height).toFixed(2)):1.78:r?r.height/r.width:.5625},a=e=>e>1.7,l=e=>1===e,c=(e,t)=>l(t)?e?"300px":"500px":a(t)?"300px":""},14736:function(e,t,r){"use strict";r.d(t,{Z:function(){return w}});var n=r(67294),i=r(26265),s=r(85893),o=r(29208),a=r.n(o),l=r(82826),c=r(73768),u=r(4201),d=r(23962),p=r(88797),f=r(33362);var m=e=>{const t=(0,l.x)(e),r=t.url,{globalContent:n}=e,i=(0,p.ic)(n),{widthsAndPresets:o,sizesConfig:a}=(0,d.GS)((0,f.xk)(n)||i),c=e=>(0,u.ZP)(r,u.PG[e]),m=`${o.map((({w:e,preset:t})=>({w:e,url:`${c(t)}${1440===e&&i?"&impolicy=high_res":""}`}))).filter((e=>null===e||void 0===e?void 0:e.url)).map((e=>`${e.url} ${e.w}w`)).join(",")}`,h=`${Object.values(a).map((e=>e)).join(",")}`;return t&&"image"===t.type&&t.url?(0,s.jsx)("link",{rel:"preload",as:"image",href:r,imagesrcset:m,imagesizes:h}):null};function h(e,t){var r=Object.keys(e);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(e);t&&(n=n.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),r.push.apply(r,n)}return r}function g(e){for(var t=1;t<arguments.length;t++){var r=null!=arguments[t]?arguments[t]:{};t%2?h(Object(r),!0).forEach((function(t){(0,i.Z)(e,t,r[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(r)):h(Object(r)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(r,t))}))}return e}const b=e=>{const t=(0,l.x)(e)||{},{type:r=""}=t;if("image"===r)return(0,s.jsx)(m,g({},e));if("video"===r){const e=a()(t,"promo_image.url"),r=960,n=e?(0,u.ZP)(encodeURIComponent(e),{w:r}):c.gW;return n?(0,s.jsx)("link",{rel:"preload",as:"image",href:n},"preload-ledeart"):null}return null};var w=e=>[(0,n.createElement)(b,g(g({},e),{},{key:"preload-ledeart"})),(0,s.jsx)("link",{rel:"preload",as:"font",crossOrigin:"crossorigin",href:"https://www.washingtonpost.com/wp-stat/assets/fonts/PostoniWide-Bold.woff2"},"preload-PostoniWide"),(0,s.jsx)("link",{rel:"preload",as:"font",crossOrigin:"crossorigin",href:"https://www.washingtonpost.com/wp-stat/assets/fonts/ITC_Franklin-Bold.woff2"},"preload-Franklin-Bold"),(0,s.jsx)("link",{rel:"preload",as:"font",crossOrigin:"crossorigin",href:"https://www.washingtonpost.com/wp-stat/assets/fonts/ITC_Franklin-Light.woff2"},"preload-Franklin-Light")]},43386:function(e,t,r){"use strict";r.d(t,{Z:function(){return b}});var n=r(85893),i=r(26265),s=r(67294),o=r(45697),a=r.n(o),l=r(11773),c=r(7106);const u=({testName:e,variantId:t,props:{children:r}})=>{const n=(0,c.aq)(c.rZ[e]),i=(0,c.aq)(c.rZ[`${e}Staging`]),s=(0,c.aq)(c.rZ[`${e}Prod`]),o=(0,l.C)(i||n,s);return parseInt(t,10)===parseInt(o,10)?r:null};u.propTypes={testName:a().string.isRequired,variantId:a().string.isRequired,props:a().shape({children:a().node.isRequired})};var d=u,p=r(47283);const f=({testName:e,variantId:t,props:{children:r}})=>{const n=(0,p.kC)(p.Wz[e]),i=(0,p.kC)(p.Wz[`${e}Staging`]),s=(0,p.kC)(p.Wz[`${e}Prod`]),o=(0,l.C)(i||n,s);return t&&o&&t.toString()===o.toString()?r:null};f.propTypes={testName:a().string.isRequired,variantId:a().string.isRequired,props:a().shape({children:a().node.isRequired})};var m=f;function h(e,t){var r=Object.keys(e);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(e);t&&(n=n.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),r.push.apply(r,n)}return r}function g(e){for(var t=1;t<arguments.length;t++){var r=null!=arguments[t]?arguments[t]:{};t%2?h(Object(r),!0).forEach((function(t){(0,i.Z)(e,t,r[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(r)):h(Object(r)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(r,t))}))}return e}var b=({enabled:e=!1,children:t})=>{var r;const i={optimize:d,akamai:m},o=s.Children.toArray(t),a=o.find((e=>"control"===e.type)),l=o.filter((e=>"control"!==e.type)),c=({type:e,props:t})=>{if(!e)return null;const r=/[variant1|variant2|variant3]/gi,o=s.Children.toArray(t.children).filter((e=>{var t;return null===(t=e.type)||void 0===t?void 0:t.match(r)}));if(null!==t&&void 0!==t&&t.type&&"undefined"!==typeof i[t.type])for(let s=0;s<o.length;s+=1){const r=o[s].type.slice(7),a=i[t.type](g({testName:e,variantId:r},o[s]));if(a)return(0,n.jsx)("div",{"data-qa":`ab-test-${e}-${r}`,children:a})}return null};if(e)for(let n=0;n<l.length;n+=1){const e=c(l[n]);if(e)return e}return(null===a||void 0===a||null===(r=a.props)||void 0===r?void 0:r.children)||null}},49344:function(e,t,r){"use strict";r.r(t),r.d(t,{LazyAi2html:function(){return m}});var n=r(85893),i=r(26265),s=r(67294),o=r(91296),a=r.n(o),l=r(95967),c=r(98504),u=r(42447);function d(e,t){var r=Object.keys(e);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(e);t&&(n=n.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),r.push.apply(r,n)}return r}function p(e){for(var t=1;t<arguments.length;t++){var r=null!=arguments[t]?arguments[t]:{};t%2?d(Object(r),!0).forEach((function(t){(0,i.Z)(e,t,r[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(r)):d(Object(r)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(r,t))}))}return e}const f=({content:e,dataQA:t="ai2html",className:r="mb-sm mb-md-ns"})=>{const i=s.createRef(),o=e=>{const t=e.getAttribute("data-src");t&&e.getAttribute("src")!==t&&e.setAttribute("src",t)},l=(e,t)=>t?Array.prototype.slice.call(t.querySelectorAll(e)):[];return(0,c.Z)((()=>{i&&i.current&&i.current.querySelectorAll(".ai2html").forEach((e=>((e,t)=>{const r=i.current.querySelector(`#${e}`),n=t.namespace||"",s=()=>{const e=l(`.${n}artboard[data-min-width]`,r),t=Math.round(r.getBoundingClientRect().width);e.forEach((e=>{const r=e.getAttribute("data-min-width"),i=e.getAttribute("data-max-width");+r<=t&&(+i>=t||null===i)?(l(`.${n}aiImg`,e).forEach(o),e.style.display="block"):e.style.display="none"}))};s();const c=a()(s,200);window.addEventListener("resize",c);const u=()=>{window.removeEventListener("resize",c)};t.setup&&t.setup(r).on("cleanup",u)})(e.id,{namespace:"g-",setup:window.setupInteractive||window.getComponent})))}),[]),e?(0,n.jsx)("div",{ref:i,className:r,"data-qa":t,children:(0,n.jsx)(u.default,{content:e})}):null},m=e=>(0,n.jsxs)(l.Z,{offsetTop:300,offsetBottom:300,renderPlaceholder:e=>(0,n.jsx)("div",{ref:e}),children:[(0,n.jsx)("div",{children:"calling ai2html here"}),(0,n.jsx)(f,p({className:"pb-md"},e),e._id)]},e._id);t.default=f},36916:function(e,t,r){"use strict";r.d(t,{_G:function(){return o},dP:function(){return a},tf:function(){return l},jS:function(){return c},lK:function(){return d},cX:function(){return p}});var n=r(29208),i=r.n(n);const s=600;function o(e){const{image_type:t,subtype:r,alignment:n,additional_properties:{keywords:i=[],graphic_embed_type:s,graphic_embed_size:o}={}}=e;if(i.includes("wp-graphic")||"graphic"===t||"graphics"===r||"GraphicImage"===r&&!s)return"left"===n||"right"===n?"sm":"lg";if("GraphicImage"===r&&s){return"large"===o&&s.includes("graphic_image")||s.includes("largegraphic")?"lg":"sm"}return null}function a(e,t=""){let r;if(t)r="sm"===t?i()(e,"alignment","left"):"center";else if(2===e.slotNum||3===e.slotNum)r="left";else{const{additional_properties:{alignment:t}={},alignment:n}=e;r=n||t}return/left|right|center/.test(r)||(r=null),r}function l(e,t={}){const{width:r=s,height:n}=t;let i,o;if(o=r>300?"left"===e||"right"===e?300:s:r,n&&r===o)i=n;else{const e=r&&n?n/r:.75;i=Math.floor(e*o)}return{width:o,height:i}}function c(e={},t="",r=!1){const{width:n}=e;return!r&&("sm"===t||"number"===typeof n&&n<=300)?"fixed":"responsive"}const u=["left","right"],d=e=>{const{additional_properties:{alignment:t=null}={}}=e;return u.includes(t)?t:null},p=e=>{const{additional_properties:{placement_width:t=null}={},height:r="300"}=e,n=t&&t.replace("px","");return{width:`${n||e.width}px`,minHeight:`${Math.floor(Number(r)*(Number(n)/e.width))}px`}}},76768:function(e,t,r){"use strict";r.d(t,{BE:function(){return o},V3:function(){return a},Jd:function(){return l}});var n=r(34022),i=r(36916),s=r(67287);const o="",a=e=>{const t=[];return e.forEach((({minWidths:e,maxWidths:r,finalWidth:n})=>{let i="undefined"!==typeof n?`${n}px`:"";if(e){const[t,r]=e;i+=`(min-width: ${t}px)${"number"===typeof r?` ${r}px`:""}`}if(i+=e&&r?" and ":"",r){const[e,t]=r;i+=`(max-width: ${e}px) ${t}px`}t.push(i)})),t};function l({articleType:e="",el:t,isGroup:r=!1,ignoreDimensions:o=!1,isFullBleed:a=!1,isSideBySide:l=!1,isCenteredLayout:c=!1,captionClasses:u="",useGrid:d=!1}){var p;const f=(0,i._G)(t),m=(0,i.dP)(t,f),h=null===(p=t.additional_properties)||void 0===p?void 0:p.media_size,{width:g,height:b}=(0,i.tf)(m,t),w=(0,i.jS)(t,f,r),y=(0,s.Em)()||!1,v=(0,s.tq)()||!1;return{className:(0,n.getClasses)("center mb-sm mb-md-ns",{"mw-600 mr-auto ml-auto":"lg"===f,"mw-300 mr-auto ml-auto":"sm"===f,"ml-neg-gutter mr-neg-gutter":!d&&"lg"!==f&&"sm"!==f,"w-50-ns mw-unset-ns":r,"w-50-ns":!r&&l&&!c||!r&&"left"===m||"right"===m,"w-50":!r&&l&&c,"w-33-ns mw-unset-ns":!r&&l&&c&&!y,"ml-auto-ns mr-auto-ns":!(c&&y&&(!c||"full-bleed"!==h))&&"left"!==m&&"right"!==m,"grid-mobile-full-bleed":d&&"standard"===e||d&&!l&&c&&("left"===m||"right"===m),"fl-ns":"left"===m,"mr-md-ns ml-auto-ns":"left"===m&&l,"mt-md mb-md":"left"===m&&"right"===m&&!l&&v,"mr-md-ns ml-auto-ns mt-xs":"left"===m&&!l&&!v&&y,"mr-xs-ns ml-auto-ns mt-xs":"left"===m&&y&&!l&&r,"mr-lg-mod-ns ml-auto-ns mt-xs":"left"===m&&!v&&y&&!l&&!r,"float-left mt-xs mr-lg-mod":"left"===m&&!v&&!y&&!l,"fr-ns":"right"===m,"ml-0-ns mr-auto-ns":"right"===m&&l,"ml-0-ns mr-auto-ns mt-xs":"right"===m&&!v&&y&&!l,"ml-xs-ns mr-auto-ns mt-xs":"right"===m&&!v&&y&&!l&&r,"ml-lg-mod-ns mr-auto-ns mt-xs":"right"===m&&!v&&y&&!l&&!r,"float-right mt-xs ml-lg-mod":"right"===m&&!v&&!y&&!l}),imgClassName:"w-100 mw-100 h-auto",captionClassName:(0,n.getClasses)(`ml-gutter mr-gutter mr-auto-ns ml-auto-ns font--subhead font-xxxs mt-xs ${u}`,{center:a&&!v,left:!a||v,"gray-dark":!u}),creditsClassName:"gray-dark font--subhead",separator:"/",showCredits:!1,credits:{},caption:(()=>{var e,r,n,i,s,o,a;let l="";const c=null!==(e=t.credits)&&void 0!==e&&e.hasOwnProperty("by")?null===(r=t.credits)||void 0===r||null===(n=r.by[0])||void 0===n?void 0:n.name:void 0,u=null!==(i=t.credits)&&void 0!==i&&i.hasOwnProperty("affiliation")?null===(s=t.credits)||void 0===s||null===(o=s.affiliation[0])||void 0===o?void 0:o.name:void 0;return l=t.credits_caption_display?t.credits_caption_display:null!==(a=t.caption)&&void 0!==a&&a.includes(c||u)?t.caption:c||u?`${t.caption} (${c||u})`:null===t||void 0===t?void 0:t.caption,l})(),layout:w,width:o?null:g,height:o?null:b}}},76512:function(e,t,r){"use strict";r.d(t,{V:function(){return a}});var n=r(29208),i=r.n(n),s=r(34022),o=r(73768);function a(e){const t=i()(e,"additional_properties.embedContinuousPlay",""),r=i()(e,"video_type",""),n=i()(e,"promo_image.url",""),a=i()(e,"_id",""),l=i()(e,"credits_caption_display",""),c=(0,o.n3)(e);return{className:(0,s.getClasses)("pt-xs mb-md mr-auto-ns ml-auto-ns hide-for-print\n    "+(c>1?"flex flex-column items-center":"ml-neg-gutter mr-neg-gutter")),caption:l,isLiveVideo:r,placeholderImage:n,playthrough:!!t,uuid:a,aspectRatio:c}}},56582:function(e,t,r){"use strict";var n=r(85893),i=r(26265),s=r(67294),o=r(34022),a=r(4201),l=r(76768),c=r(15709),u=r(34155);function d(e,t){var r=Object.keys(e);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(e);t&&(n=n.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),r.push.apply(r,n)}return r}function p(e){for(var t=1;t<arguments.length;t++){var r=null!=arguments[t]?arguments[t]:{};t%2?d(Object(r),!0).forEach((function(t){(0,i.Z)(e,t,r[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(r)):d(Object(r)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(r,t))}))}return e}t.Z=({element:e,imgProps:{imgClassName:t="w-100 mw-100 h-auto"},widthsAndPresets:r,sizesConfig:i,isSideBySide:d=!1,isCenteredLayout:f})=>{var m,h,g;let b=!1===(null===(m=e.additional_properties)||void 0===m?void 0:m.published)?null===(h=e.additional_properties)||void 0===h?void 0:h.resizeUrl:e.url;const w=e.alt||e.caption||l.BE,y=(0,c.J)(b),{width:v,height:j}=e;if(y){const e=new URL(b);e.protocol="https:",b=e.href}const O=e=>y?b:(0,a.ZP)(b,a.PG[e]),P=r.map((({w:e,preset:t,useHighResolution:r})=>({w:e,url:`${O(t)}${r&&"true"!==u.env.NEXT_PUBLIC_IS_PREVIEW?"&impolicy=high_res":""}`}))),x="true"!==u.env.NEXT_PUBLIC_IS_PREVIEW?`${P.filter((e=>null===e||void 0===e?void 0:e.url)).map((e=>`${e.url} ${e.w}w`)).join(",")}`:b;if(!x)return null;const C=`${Object.values(i).map((e=>e)).join(",")}`,A=s.useRef(),[_,S]=s.useState(!1),[E,k]=s.useState(!1);(0,s.useEffect)((()=>{S(!0),A.current&&(A.current.complete?k(!0):A.current.addEventListener("load",(()=>{k(!0)})))}),[A,_]);const N=d?{"--aspect-width":v,"--aspect-height":j}:{},D=null===(g=e.additional_properties)||void 0===g?void 0:g.media_size,B=f&&!e.alignment?{small:{maxHeight:600},medium:{maxHeight:975}}[D]:{};return(0,n.jsx)(s.Fragment,{children:(0,n.jsx)("div",{style:p({filter:!1===E?"blur(10px)":"blur(0)",transition:"filter .1s",lineHeight:0},N),className:(0,o.getClasses)(t,{"aspect-custom":d}),width:d?"":v,height:d?"":j,children:(0,n.jsx)("img",p(p({},!1===E&&{style:{position:"absolute",left:0}}),{},{alt:w,className:(0,o.getClasses)(t,{"of-cover":d}),width:d?"":v,height:d?"":j,srcSet:x,sizes:C,ref:A,decoding:"async",style:p({backgroundSize:"cover",maxWidth:"1600px",backgroundImage:"url('data:image/svg+xml;charset=utf-8,%3Csvg xmlns='http%3A//www.w3.org/2000/svg'        xmlns%3Axlink='http%3A//www.w3.org/1999/xlink' viewBox='0 0 1280 853'%3E%3Cfilter id='b' color-interpolation-filters='sRGB'%3E%3CfeGaussianBlur stdDeviation='.5'%3E%3C/feGaussianBlur%3E%3CfeComponentTransfer%3E%3CfeFuncA type='discrete' tableValues='1 1'%3E%3C/feFuncA%3E%3C/feComponentTransfer%3E%3C/filter%3E%3Cimage filter='url(%23b)' x='0' y='0' height='100%25' width='100%25'         xlink%3Ahref='data%3Aimage/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAkAAAAGCAIAAACepSOSAAAACXBIWXMAAC4jAAAuIwF4pT92AAAAs0lEQVQI1wGoAFf/AImSoJSer5yjs52ktp2luJuluKOpuJefsoCNowB+kKaOm66grL+krsCnsMGrt8m1u8mzt8OVoLIAhJqzjZ2tnLLLnLHJp7fNmpyjqbPCqLrRjqO7AIeUn5ultaWtt56msaSnroZyY4mBgLq7wY6TmwCRfk2Pf1uzm2WulV+xmV6rmGyQfFm3nWSBcEIAfm46jX1FkH5Djn5AmodGo49MopBLlIRBfG8yj/dfjF5frTUAAAAASUVORK5CYII='%3E%3C/image%3E%3C/svg%3E')"},B)}))})})}},82826:function(e,t,r){"use strict";r.d(t,{Z:function(){return A},x:function(){return C}});var n=r(85893),i=r(26265),s=r(67294),o=r(29208),a=r.n(o),l=r(34022),c=r(30),u=r(76512),d=r(3642),p=r(23962),f=r(33362),m=r(38347),h=r(49344);function g(e,t){var r=Object.keys(e);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(e);t&&(n=n.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),r.push.apply(r,n)}return r}function b(e){for(var t=1;t<arguments.length;t++){var r=null!=arguments[t]?arguments[t]:{};t%2?g(Object(r),!0).forEach((function(t){(0,i.Z)(e,t,r[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(r)):g(Object(r)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(r,t))}))}return e}var w=({element:e={}})=>{const{content:t,additional_properties:r}=e,i=r||{},{fallback_image_url:{url:o}={},fallback_image_min_height:a}=i,l=(0,m.Z)(i.fallback_image_url,["url"]),{0:c,1:u}=(0,s.useState)(!1);if((0,s.useEffect)((()=>{u(!0)}),[]),!t&&!o)return null;const d=b(b(b({},e),l),{},{url:o,alt:l.description,captionClassName:"z-3 left gray-dark font--subhead font-xxxs w-md mw-md ma-auto pr-sm pl-sm pl-sm mb-sm"}),f="string"===typeof a?a.replace(/\s/g,""):a;return(0,n.jsxs)("div",{style:{minHeight:f||462},className:"relative mw-100","data-qa":"lede-ai2html",children:[!c&&(0,n.jsx)("div",{className:"absolute w-100",style:{left:"50%",transform:"translate(-50%, 0)"},children:(0,n.jsx)(p.ZP,{element:d,isFullWidth:!0})}),(0,n.jsxs)("div",{className:"mb-sm "+(c?"db":"dn"),children:[(0,n.jsx)(h.default,{content:t}),(0,n.jsx)(p.ik,{imgProps:d})]})]})},y=r(76768),v=r(46519),j=r(56582),O=r(88797);function P(e,t){var r=Object.keys(e);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(e);t&&(n=n.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),r.push.apply(r,n)}return r}function x(e){for(var t=1;t<arguments.length;t++){var r=null!=arguments[t]?arguments[t]:{};t%2?P(Object(r),!0).forEach((function(t){(0,i.Z)(e,t,r[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(r)):P(Object(r)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(r,t))}))}return e}const C=e=>{const t=a()(e.globalContent,"content_elements",""),r=(0,f.If)(e.globalContent),{globalContent:{promo_items:{basic:n,centered_layout:i}={},related_content:{primary_slot:[s={}]=[]}={}}={}}=e,o="Voraciously"===r&&n,l=(0,O.ic)(e.globalContent)||(0,f.cF)(e.globalContent),u=(0,f.Wn)(e.globalContent)||l&&(0,c.q)(i)||(0,c.q)(s)||(0,c.q)(t[0])||o;return(0,c.x)(t)?{}:u};var A=e=>{const t=(0,v.Z)(),{isFullWidth:r,isFullBleed:i,isSplitTopper:s,noBleedMobile:o=!0,hasFigCaption:c,captionClasses:f,className:m}=e,h=C(e);if(!h)return null;const{type:g,subtype:b,content:O}=h;if(i&&"image"===g){const e=[{w:440,preset:"440"},{w:691,preset:"691"},{w:1440,preset:"large",useHighResolution:!0}],r=(0,y.V3)([{maxWidths:[440,440]},{minWidths:[441],maxWidths:[1400,691]},{minWidths:[1441,1440]}]),o=x(x({},(0,y.Jd)({el:h,noBleedMobile:!0,isFullBleed:i,captionClasses:f})),{},{layout:"fill"});return(0,n.jsxs)("div",{"data-qa":"lede-art",children:[(0,n.jsx)("div",{style:{minHeight:t?"50vw":""},children:(0,n.jsx)(j.Z,{element:h,imgProps:o,widthsAndPresets:e,sizesConfig:r})}),!s&&(0,n.jsx)("div",{style:{maxWidth:"700px",width:t?"":"92%"},className:"ma-auto",children:(0,n.jsx)(p.ik,{element:h,imgProps:o})})]})}if("image"===g&&h.url)return(0,n.jsx)("div",{"data-qa":"lede-art",className:(0,l.getClasses)("",{"w-100":r}),children:(0,n.jsx)(p.ZP,{element:h,isFullWidth:r,noBleedMobile:o,isFullBleed:i,hasFigCaption:c,captionClasses:f,className:m},h._id)});if(("ai2html"===b||"graphic"===b)&&O)return(0,n.jsx)("div",{"data-qa":"lede-art",children:(0,n.jsx)(w,{element:h},h._id)});if("video"===g){const e=(0,u.V)(h);return(0,n.jsx)("div",{"data-qa":"lede-art",children:(0,n.jsx)(d.default,{uuid:h._id,videoConfig:e,alternateArt:a()(e,"placeholderImage")})})}return null}},30:function(e,t,r){"use strict";r.d(t,{q:function(){return i},x:function(){return s}});var n=r(36916);const i=(e={})=>{const{type:t,subtype:r}=e;if("video"===t)return e;if("image"===t||"raw_html"===t&&"graphic"===r){const t=(0,n.dP)(e,(0,n._G)(e));return"right"!==t&&"left"!==t&&e}return!1},s=e=>{const[t={},r={}]=e;return!(1!==e.length||!i(t))||!(!i(t)||!i(r))}},99151:function(e,t,r){"use strict";var n=r(85893),i=r(67294),s=r(77449);t.Z=({children:e})=>(0,n.jsx)(i.Fragment,{children:i.Children.map(e,(e=>(0,n.jsx)(s.Z,{children:e})))})},11773:function(e,t,r){"use strict";r.d(t,{C:function(){return i}});var n=r(60200);const i=(e,t)=>(0,n.B)()?t:e},22527:function(e,t,r){"use strict";var n=r(67294),i=r(67287);t.Z=function(){const{0:e,1:t}=(0,n.useState)(!1),r=()=>{t((0,i.nI)())};return(0,n.useEffect)((()=>(r(),window.addEventListener("resize",r),()=>window.removeEventListener("resize",r))),[]),e}},98504:function(e,t,r){"use strict";var n=r(67294);const i=window.document&&window.document.createElement?n.useLayoutEffect:n.useEffect;t.Z=i}}]);