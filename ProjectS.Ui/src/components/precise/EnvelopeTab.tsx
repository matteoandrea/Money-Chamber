import { JSXElement, createSignal } from 'solid-js';
import EvelopeTab from '../../Models/EnvelopeTab';






export default function EnvelopeTab() {
    const [activeTab, setActiveTab] = createSignal(1);

    const tabs: EvelopeTab = new EvelopeTab();
    const handleTabClick = (tabId: number) => {
        setActiveTab(tabId);
    };

    return (
        <div role="tablist" class="tabs tabs-bordered">
            {tabs.tabs.map((tab) => (
                <a
                    role="tab"
                    class={`tab ${activeTab() === tab.id ? 'tab-active' : ''}`}
                    onClick={() => handleTabClick(tab.id)}
                >
                    {tab.label}
                </a>
            ))}

            {tabs.tabs.map((tab) => (
                <div style={{ display: activeTab() === tab.id ? 'block' : 'none' }}>
                    {tab.content}
                </div>
            ))}
        </div>
    );
}
