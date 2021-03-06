import React, { Component, PropTypes } from "react";
import Collapse from "dnn-collapsible";
import { SearchIcon } from "dnn-svg-icons";
import Localization from "../../localization";
import SearchAdvancedDetails from "./SearchAdvancedDetails";
import "./styles.less";


class SearchAdvanced extends Component {
    constructor(props) {
        super(props);
        this.state = {
            collapsed:false
        };
    }

    toggle() {
        this.setState({
            collapsed:!this.state.collapsed
        });
    }

    onClear() {
        this.setState({
            collapsed : false
        });
    }

    /*eslint-disable react/no-danger*/
    render() {
        return (
            <div className={`advancedCollapsibleComponent ${this.state.collapsed?"open":""}`}>
                <div className={`collapsible-header false` } onClick={this.toggle.bind(this)}>
                    <div className="search-advanced-header">
                        <div className="search-advanced-icon" dangerouslySetInnerHTML={{ __html: SearchIcon }}>
                        </div>
                        <div className="search-advanced-label">
                            {Localization.get("AdvancedFilters")}
                        </div>
                    </div>
                    <span
                        className={`collapse-icon ${this.state.collapsed?"collapsed":""}`}>
                    </span>
                </div>
                <Collapse isOpened={this.state.collapsed} className="search-header-collapsible">
                        {this.state.collapsed && 
                            <SearchAdvancedDetails 
                                getFilterByPageTypeOptions={this.props.getFilterByPageTypeOptions}
                                getFilterByPageStatusOptions={this.props.getFilterByPageStatusOptions}
                                getFilterByWorkflowOptions={this.props.getFilterByWorkflowOptions}
                                filterByWorkflow={this.props.filterByWorkflow}
                                onApplyChangesDropdownDayPicker={this.props.onApplyChangesDropdownDayPicker}
                                updateFilterByPageTypeOptions={this.props.updateFilterByPageTypeOptions}
                                updateFilterByPageStatusOptions={this.props.updateFilterByPageStatusOptions}
                                updateFilterByWorkflowOptions={this.props.updateFilterByWorkflowOptions}
                                filterByPageType={this.props.filterByPageType}
                                filterByPublishStatus={this.props.filterByPublishStatus}
                                onDayClick={this.props.onDayClick}
                                startDate={this.props.startDate}
                                endDate={this.props.endDate}
                                startAndEndDateDirty={this.props.startAndEndDateDirty}
                                tags={this.props.tags}
                                onSearch={this.props.onSearch}
                                collapsed={this.state.collapsed}
                                clearAdvancedSearch={this.props.clearAdvancedSearch}
                                clearAdvancedSearchDateInterval={this.props.clearAdvancedSearchDateInterval}
                                updateSearchAdvancedTags={this.props.updateSearchAdvancedTags}
                            />
                        }
                </Collapse>    
            </div>
        );
    }
}

SearchAdvanced.propTypes = {
    getFilterByPageTypeOptions : PropTypes.func.isRequired,
    getFilterByPageStatusOptions : PropTypes.func.isRequired,
    getFilterByWorkflowOptions : PropTypes.func.isRequired,
    filterByWorkflow : PropTypes.func.isRequired,
    onApplyChangesDropdownDayPicker : PropTypes.func.isRequired,
    updateFilterByPageTypeOptions : PropTypes.func.isRequired,
    updateFilterByPageStatusOptions : PropTypes.func.isRequired,
    updateFilterByWorkflowOptions : PropTypes.func.isRequired,
    filterByPageType : PropTypes.string.isRequired,
    filterByPublishStatus : PropTypes.string.isRequired,
    onDayClick : PropTypes.func.isRequired,
    startDate : PropTypes.instanceOf(Date).isRequired,
    endDate : PropTypes.instanceOf(Date).isRequired,
    startAndEndDateDirty : PropTypes.bool.isRequired,
    tags : PropTypes.string.isRequired,
    onSearch : PropTypes.func.isRequired,
    clearAdvancedSearch : PropTypes.func.isRequired,
    clearAdvancedSearchDateInterval : PropTypes.func.isRequired,
    updateSearchAdvancedTags : PropTypes.func.isRequired
};

export default SearchAdvanced;