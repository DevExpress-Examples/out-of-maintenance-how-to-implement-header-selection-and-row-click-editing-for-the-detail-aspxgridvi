<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/TestGridViewSite81/Default.aspx) (VB: [Default.aspx](./VB/TestGridViewSite81/Default.aspx))
* [Default.aspx.cs](./CS/TestGridViewSite81/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/TestGridViewSite81/Default.aspx.vb))
<!-- default file list end -->
# How to implement header selection and row click editing for the detail ASPxGridView
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e312/)**
<!-- run online end -->


<p>The example demonstrates how to handle the Init events to assign custom scripts that allow changing grid's selection dynamically and editing it when a row is clicked.</p><p><strong>See also:</strong><br />
<a href="https://www.devexpress.com/Support/Center/p/K18253">ASPxGridView - How to implement SelectRows and SelectAllRowsOnPage CheckBox features</a></p>


<h3>Description</h3>

<p>All this functionality can be implemented using the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewASPxGridView_HtmlRowCreatedtopic">HtmlRowCreated</a> event of the master ASPxGridView. In this event handler, you should obtain a detail ASPxGridView instance and set client side event handlers for its elements.</p>

<br/>


